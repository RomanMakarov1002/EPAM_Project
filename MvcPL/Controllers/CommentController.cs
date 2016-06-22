using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfacies.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;

namespace MvcPL.Controllers
{
    public class CommentController : Controller
    {      
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;

        public CommentController(ICommentService service, IUserService userService)
        {
            _commentService = service;
            _userService = userService;
        }
  
        [HttpPost]
        [Authorize]
        public ActionResult Create(string Text, int id)
        {
            if (!String.IsNullOrWhiteSpace(Text))
            {
                var fullcomment = new FullCommentViewModel();
                fullcomment.ArticleId = id;
                fullcomment.User = _userService.GetUserByNickname(User.Identity.Name).ToMvcUser();
                fullcomment.DateTime = DateTime.Now;
                fullcomment.Text = Text;
                _commentService.CreateCommentEntity(fullcomment.ToBllFullComment());
                if (Request.IsAjaxRequest())
                    return Json(fullcomment);

            }
            else
            {
                ModelState.AddModelError("Text", "Add your message");
            }
            return RedirectToAction("Details", "Article", new { id });
        }


        [HttpGet]
        [Authorize(Roles = "Administrator,Moderator")]
        public ActionResult Edit(int id)
        {
            var comment = _commentService.GetCommentEntity(id).ToMvcFullComment();
            return View(comment);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator,Moderator")]
        public ActionResult Edit(FullCommentViewModel comment)
        {
            if (comment != null && !String.IsNullOrWhiteSpace(comment.Text))
                _commentService.UpdateCommentEntity(comment.ToBllFullComment());
            return RedirectToAction("Details", "Article", new {id = comment.ArticleId});
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var comment = _commentService.GetCommentEntity(id)?.ToMvcFullComment();
            if (comment != null)
                return View(comment);
            return RedirectToAction("Index","Article");
        }

        //
        // POST: /Post/Delete/5

        [HttpPost]
        [Authorize(Roles = "Administrator,Moderator")]
        public ActionResult Delete(FullCommentViewModel commentModel)
        {
            _commentService.DeleteCommentEntity(commentModel.ToBllFullComment());
            return RedirectToAction("Details","Article", new {id = commentModel.ArticleId});
        }
    }
}

