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
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            this._tagService = tagService;
        }
        //
        // GET: /Tag/
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(_tagService.GetAllTagEntities().Select(x => x.ToMvcSimpleTag()));
        }

        //
        // GET: /Tag/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Tag/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tag/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(SimpleTagViewModel tag)
        {
            try
            {
                if (ModelState.IsValid)
                _tagService.CreateTag(tag.ToBllSimpleTag());
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Create");
            }
        }

        //
        // GET: /Tag/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            return View(_tagService.GetTagEntity(id)?.ToMvcSimpleTag());
        }

        //
        // POST: /Tag/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(SimpleTagViewModel tag)
        {
            try
            {   if (ModelState.IsValid)
                _tagService.UpdateTag(tag.ToBllSimpleTag());
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Edit", new {id = tag.Id});
            }
        }
        
    }
}
