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
            if (ModelState.IsValid)
                _tagService.CreateTag(tag.ToBllSimpleTag());
            return RedirectToAction("Index");
           
        }

        //
        // GET: /Tag/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            var tag = _tagService.GetTagEntity(id)?.ToMvcSimpleTag();
            if (tag != null)
                return View(tag);
            return RedirectToAction("Index");
        }

        //
        // POST: /Tag/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(SimpleTagViewModel tag)
        {
            if (ModelState.IsValid)
                _tagService.UpdateTag(tag.ToBllSimpleTag());
            return RedirectToAction("Index");                     
        }
        
    }
}
