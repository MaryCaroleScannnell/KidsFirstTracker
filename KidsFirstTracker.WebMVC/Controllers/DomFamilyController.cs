﻿using KidsFirstTracker.Models;
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
            var model = new DomFamilyListItem[0];

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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }

    }
}