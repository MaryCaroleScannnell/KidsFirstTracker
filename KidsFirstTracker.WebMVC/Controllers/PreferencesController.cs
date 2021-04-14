using KidsFirstTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidsFirstTracker.WebMVC.Controllers
{
    [Authorize]
    public class PreferencesController : Controller
    {
        // GET: Preferences
        public ActionResult Index()
        {
            var model = new PreferencesListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PreferencesCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}