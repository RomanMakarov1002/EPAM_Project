using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interfacies.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;
using MvcPL.Infrastructure;
using MvcPL.Providers;


namespace MvcPL.Controllers
{
    public class UserController : Controller
    {
        public const int DefaultRole = 3;
        private readonly IUserService _userService;

        private readonly IRoleService _roleService;

        public UserController(IUserService service, IRoleService roleService)
        {
            this._userService = service;
            this._roleService = roleService;
        }

        [Authorize(Roles = "Administrator")]
        [ActionName("Index")]
        public ActionResult GetAllUsers()
        {
            return View(_userService.GetAllUserEntities().Select(x => _userService.GetFullUserEntity(x).ToFullMvcUser()));
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Article");
            return View("SignIn");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(string NickName, string Password, string ReturnUrl)
        {
            if (Membership.ValidateUser(NickName, Password))
            {
                FormsAuthentication.SetAuthCookie(NickName, true);
                if (Url.IsLocalUrl(ReturnUrl))
                    return Redirect(ReturnUrl);
                return RedirectToAction("Index", "Article");
       
            }
            ModelState.AddModelError("", "Incorrect login or password");
            return View("SignIn");
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View("Registration");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(FullUserViewModel userViewModel, HttpPostedFileBase PictureInput)
        {
            if (userViewModel.Captcha != (string)Session[Infrastructure.Captcha.CaptchaValueKey])
            {
                ModelState.AddModelError("Captcha", "Incorrect captcha input");
                return View(userViewModel);
            }
            if (ModelState.IsValid)
            {
                if (_userService.GetUserByEmail(userViewModel.Email) != null)
                    ModelState.AddModelError("Email", "User with this Email already exists");
                else if (_userService.GetUserByNickname(userViewModel.NickName) != null)
                    ModelState.AddModelError("NickName", "User with this NickName already exists");
                else
                {
                    var membershipUser = ((CustomMembershipProvider)Membership.Provider).GetUser(
                        userViewModel.NickName, false);
                    if (membershipUser == null)
                    {
                        var t = new List<SimpleRoleViewModel>();
                        t.Add(_roleService.GetRoleEntity(DefaultRole)?.ToMvcSimpleRole());        //adding visitor role
                        userViewModel.Roles = t;
                        userViewModel.JoinTime = DateTime.Now;
                        userViewModel.Password = HashForPassword.GenerateHash(userViewModel.Password);
                        var str = new StringBuilder();
                        if (PictureInput != null)
                            str.Append(ImageHelper.SaveFileToDisk(PictureInput, Server.MapPath("~/")));
                        userViewModel.AvatarPath = "/UserContent/" + str;
                        _userService.CreateFullUser(userViewModel.ToFullBllUser());
                        FormsAuthentication.SetAuthCookie(userViewModel.NickName, false);
                        return RedirectToAction("Index", "Article");
                    }
                    ModelState.AddModelError("", "This user already exist");
                }
            }
            return View(userViewModel);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Article");   
        }
      
        
        [HttpPost]
        public JsonResult SearchNickname(string NickName)
        {
            return Json(_userService.GetUserByNickname(NickName) == null);
        }

        [HttpPost]
        public JsonResult SearchEmail(string Email)
        {
            if (!Email.Contains('@'))
                return Json(true);
            return Json(_userService.GetUserByEmail(Email) == null);
        }


        [HttpGet]
        [Authorize]
        public ActionResult Details(string nickname)
        {
            if (nickname != User.Identity.Name)
                return RedirectToAction("Registration");
            return View(_userService.GetUserByNickname(nickname)?.ToMvcEditorUser());
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Details(UserEditorViewModel userViewModel, HttpPostedFileBase PictureInput)
        {
            if (PictureInput != null)
            {
                StringBuilder str = new StringBuilder();
                str.Append(ImageHelper.SaveFileToDisk(PictureInput, Server.MapPath("~/")));
                userViewModel.AvatarPath = "/UserContent/" + str;
            }
            userViewModel.NewPassword = HashForPassword.GenerateHash(userViewModel.NewPassword);
            _userService.UpdateUser(userViewModel.ToBllUserEntity());
            return View(userViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            return View(_userService.GetFullUserEntity(_userService.GetUserEntity(id))?.ToFullMvcUser());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(FullUserViewModel userViewModel, int[] Role)
        {
            if (Role != null && Role.Length>0)
            {
                userViewModel.Roles = Role.Select(x => _roleService.GetRoleEntity(x).ToMvcSimpleRole());
                _userService.UpdateUserRoles(userViewModel.ToFullBllUser());
            }
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult Captcha()
        {
            Session[Infrastructure.Captcha.CaptchaValueKey] =
                new Random(DateTime.Now.Millisecond).Next(1111, 9999).ToString(CultureInfo.InvariantCulture);
            var ci = new Captcha(Session[Infrastructure.Captcha.CaptchaValueKey].ToString(), 211, 50, "Helvetica");

            this.Response.Clear();
            this.Response.ContentType = "image/jpeg";

            ci.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);

            ci.Dispose();
            return null;
        }

        public ActionResult Partial()
        {
            return PartialView("PartialRoles", _roleService.GetAllRoleEntities().Select(x => x.ToMvcSimpleRole()));
        }       
    }
}