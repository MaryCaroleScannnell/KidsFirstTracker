﻿using KidsFirstTracker.Models;
using KidsFirstTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidsFirstTracker.WebMVC.Controllers
{
    [Authorize]
    public class DomFamilyController : Controller
    {
        // GET: DomFamily
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DomFamilyService(userId);
            var model = service.GetDomFamily();


            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DomFamilyCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateDomFamilyService();


            if (service.CreateDomFamily(model))
            {
                TempData["SaveResult"] = "Your family was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Family could not be created");

            return View(model);
        }

        private DomFamilyService CreateDomFamilyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DomFamilyService(userId);
            return service;
        }
    }
}