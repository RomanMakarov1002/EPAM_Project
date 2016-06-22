using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BLL.Interfacies.Services;
using MvcPL.Infrastructure;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models;

namespace MvcPL.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ITagService _tagService;
        private readonly IUserService _userService;
        private readonly IBlogService _blogService;

        public ArticleController(IArticleService articleService, ITagService tagService, IUserService userService, IBlogService blogService)
        {
            this._articleService = articleService;
            this._tagService = tagService;
            this._userService = userService;
            this._blogService = blogService;
        }


        public ActionResult Index(int page = 1)
        {
            int pageSize = 4;
            var result = new PagingViewModel<FullArticleViewModel>();
            int totalItems =0;
            result.Items =
                _articleService.GetArticlesForPage((page - 1) * pageSize, pageSize, ref totalItems)
                    .Select(x => _articleService.GetFullArticleEntity(x).ToMvcFullArticle());

            result.Paging = new Paging { PageNumber = page, PageSize = pageSize, TotalItems = totalItems};
            if (Request.IsAjaxRequest())
            {
                return PartialView("ContentPartial", result);
            }
            return View(result);
        }

  
        public ActionResult SortedByTag(int id, int page = 1)
        {
            int pageSize = 4;
            var result = new PagingViewModel<FullArticleViewModel>();
            result.Name = _tagService.GetTagEntity(id)?.Name;
            result.Id = id;
            int totalItems = 0;
            result.Items =
                _articleService.GetForPageByTag(id, (page - 1) * pageSize, pageSize , ref totalItems)
                    .Select(x => _articleService.GetFullArticleEntity(x).ToMvcFullArticle());

            result.Paging = new Paging { PageNumber = page, PageSize = pageSize, TotalItems = totalItems };
            if (Request.IsAjaxRequest())
            {
                return PartialView("ContentPartial", result);
            }
            return View(result);
        }


        //
        // GET: /Article/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(_articleService.GetFullArticleEntity(_articleService.GetArticleEntity(id))?.ToMvcFullArticle());
            }
            catch
            {
                return RedirectToAction("Index", "Article");
            }
        }

        //
        // GET: /Article/Create
        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var articleform = new FullArticleViewModel();
            articleform.User = _userService.GetUserByNickname(User.Identity.Name)?.ToMvcUser();
            return View(articleform);
        }

        //
        // POST: /Article/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(FullArticleViewModel articleViewModel, int[] Tags,  HttpPostedFileBase PictureInput, int BlogId = 0)
        {
            try
            {
                if (ModelState.IsValidField("Text") && ModelState.IsValidField("Title"))
                {

                    if (BlogId == 0 || Tags == null)
                        return RedirectToAction("Create");
                    articleViewModel.CreationTime = DateTime.Now;
                    articleViewModel.Tags = Tags.Select(x => _tagService.GetTagEntity(x)?.ToMvcSimpleTag());
                    articleViewModel.User = _userService.GetUserByNickname(User.Identity.Name)?.ToMvcUser();
                    articleViewModel.Blog = _blogService.GetSimpleBlogById(BlogId).ToMvcSimpleBlog();
                    var str = new StringBuilder();
                    if (PictureInput != null)
                        str.Append(ImageHelper.SaveTitleImgToDisk(PictureInput, Server.MapPath("~/")));
                    articleViewModel.TitleImage = "/ArticlesContent/" + str;
                    _articleService.CreateFullArticleEntity(articleViewModel.ToBllFullArticle());
                }
                return RedirectToAction("Index");
            }                               
            catch
            {
                return RedirectToAction("Create");
            }
        }

       
        // GET: /Article/Edit/
        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = _userService.GetUserByNickname(User.Identity.Name);
            var result = _articleService.GetArticleEntity(id)?.ToMvcSimpleArticle();
            if (result != null)
            {
                if (User.IsInRole("Administrator") || User.IsInRole("Moderator") || userId.Id == result.UserId)
                {
                    return View(result);
                }
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Article/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(SimpleArticleViewModel article, int[] Tags, HttpPostedFileBase PictureInput)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = _userService.GetUserByNickname(User.Identity.Name);
                    if (User.IsInRole("Administrator") || User.IsInRole("Moderator") || userId.Id == article.UserId)
                    {
                        if (PictureInput != null)
                        {
                            StringBuilder str = new StringBuilder();
                            str.Append(ImageHelper.SaveTitleImgToDisk(PictureInput, Server.MapPath("~/")));
                            article.TitleImage = "/ArticlesContent/" + str;
                        }
                        if (Tags != null)
                        {
                            _articleService.UpdateTags(article.Id, Tags);
                        }
                        _articleService.UpdateSimpleArticle(article.ToBllSimpleArticle());
                        return RedirectToAction("Index");
                    }
                    return RedirectToAction("Edit", new { id = article.Id });
                }
                return View();
            }
            catch
            {
                return RedirectToAction("Edit", new { id = article.Id });
            }
        }

        //
        // GET: /Article/Delete/5
        [Authorize(Roles = "Administrator,Moderator")]
        public ActionResult Delete(int id)
        {
            var fullArticle =
                _articleService.GetFullArticleEntity(_articleService.GetArticleEntity(id))?.ToMvcFullArticle();
            if (fullArticle != null)
            {
                return View(fullArticle);
            }
            return HttpNotFound();
        }

        //
        // POST: /Article/Delete/5
        [HttpPost]
        [Authorize(Roles = "Administrator,Moderator")]
        public ActionResult Delete(FullArticleViewModel fullArticle, int blogId, int userId)
        {
            try
            {
                fullArticle.User = _userService.GetUserEntity(userId)?.ToMvcUser();
                fullArticle.Blog = _blogService.GetSimpleBlogById(blogId)?.ToMvcSimpleBlog();
                _articleService.DeleteArticle(fullArticle.ToBllFullArticle());
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Delete", new {id = fullArticle.Id});
            }
        }

        [HttpGet]
        public ActionResult PartialTags()
        {
            return PartialView(_tagService.GetAllTagEntities().Select(x => x.ToMvcSimpleTag()));
        }

        public ActionResult GetAllTags()
        {
            return PartialView("AllTagsPartial", _tagService.GetAllTagEntities().Select(x => x.ToMvcSimpleTag()));
        }
    }
}
