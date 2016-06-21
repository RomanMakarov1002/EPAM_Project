using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfacies.Entities;
using BLL.Interfacies.Services;

namespace MvcPL.Controllers
{
    public class SearchController : Controller
    {
        //
        private readonly ITagService _tagService;
        private readonly IArticleService _articleService;

        public SearchController(ITagService tagService, IArticleService articleService)
        {
            this._tagService = tagService;
            this._articleService = articleService;
        }

        
        public JsonResult FindMatches(string term)
        {
            if (term != null && term.Length > 1)
            {
                var tags = _tagService.SearchTags(term.Split(' ').First()).Select(x => new {label = x }).ToList();
                if (term.Length > 3)
                {
                    tags.AddRange(_articleService.SearchText(term).Select(x => new {label = x}));
                }

                return Json(tags, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        
        public ActionResult By(string id)
        {          
            if (id == null || id.Length < 2)
            {
                return View("NothingFound");
            }
            var result = new SearchModel();
            result.Tags = _tagService.FindTags(id.Split(' ').First());
            result.Articles = _articleService.FindByText(id);
            return View("Index",result);
        }
    }
}
