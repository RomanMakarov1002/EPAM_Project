using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfacies.Services;
using MvcPL.Infrastructure;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;

namespace MvcPL.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IUserService _userService;
        private readonly IArticleService _articleService;

        public BlogController(IBlogService blogService, IUserService userService, IArticleService articleService)
        {
            this._blogService = blogService;
            this._userService = userService;
            this._articleService = articleService;
        }


        public ActionResult GetAllBlogs()
        {
            var blogs = _blogService.GetAllSimpleBlogs().Select(x => x.ToMvcSimpleBlog());
            return PartialView("AllBlogsPartial", blogs);
        }


        //
        // GET: /Blog/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Blog/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FullBlogViewModel blog)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(blog.Name))
                {
                    blog.User = _userService.GetUserByNickname(User.Identity.Name)?.ToMvcUser();
                    _blogService.CreateBlog(blog.ToBllFullBlog());
                    return RedirectToAction("Index", "Article");
                }
                return RedirectToAction("Create", "Blog");
            }
            catch
            {
                return RedirectToAction("Create", "Blog");
            }
        }


        public ActionResult Index(int id, int page = 1)
        {
            int pageSize = 4;
            var result = new PagingViewModel<FullArticleViewModel>();
            result.Name = _blogService.GetSimpleBlogById(id)?.Name;
            result.Id = id;
            result.Items =
                _articleService.GetAllByBlog(id).Skip((page - 1) * pageSize).Take(pageSize)
                    .Select(x => _articleService.GetFullArticleEntity(x).ToMvcFullArticle());
            result.Paging = new Paging { PageNumber = page, PageSize = pageSize, TotalItems = _articleService.GetAllByBlog(id).Count() };
            if (Request.IsAjaxRequest())
            {
                return PartialView("ContentPartial", result);
            }
            return View("Content", result);
        }

        public ActionResult GetUserBlogs(int id)
        {
            var blogs = _blogService.GetAllByUser(id).Select(x => x.ToMvcSimpleBlog());
            return PartialView("UserBlogsPartial", blogs);
        }
          
        
        //
        // GET: /Blog/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var blog = _blogService.GetBlogById(id)?.ToMvcFullBlog();
            if (blog == null)
                return HttpNotFound();  //
            return View (blog);
        }

        //
        // POST: /Blog/Delete/5

        [HttpPost]
        [Authorize]
        public ActionResult Delete(FullBlogViewModel fullblog)
        {
            try
            {
                fullblog = _blogService.GetBlogById(fullblog.Id)?.ToMvcFullBlog();
                if (User.Identity.Name != fullblog.User.NickName)
                {
                    return RedirectToAction("Index", "Article");
                }
                fullblog.Articles = _articleService.GetAllByBlog(fullblog.Id).Select(x => _articleService.GetFullArticleEntity(x).ToMvcFullArticle()).ToList();
                _blogService.DeleteBlog(fullblog.ToBllFullBlog());
                return RedirectToAction("Index", "Article");
            }
            catch
            {
                return RedirectToAction("Profile");
            }
        }

        public new ActionResult Profile()
        {
            var user = _userService.GetUserByNickname(User.Identity.Name);
            var profile =
                    _blogService.GetAllByUser(user.Id).Select(x => _blogService.GetBlogById(x.Id).ToMvcFullBlog()).ToList();
            foreach (var item in profile)
            {
                item.Articles = _articleService.GetAllByBlog(item.Id).Select(x => _articleService.GetFullArticleEntity(x).ToMvcFullArticle()).ToList();
            }
            if (!profile.Any())
            {
                List<FullBlogViewModel> res = new List<FullBlogViewModel>() { new FullBlogViewModel()
                {
                   User = user.ToMvcUser()
                } };
                profile = res;
            } 
         
            return View(profile);
        }
    }
}
