using KidsFirstTracker.Models;
using KidsFirstTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidsFirstTracker.WebMVC.Controllers
{
    [Authorize]
    public class HomeStudyController : Controller
    {
        // GET: HomeStudy
        public ActionResult Index()
        {
            var service = new HomeStudyService();
            var model = service.GetHomeStudy();


            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HomeStudyCreate model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }
            var service = new HomeStudyService();
            service.CreateHomeStudy(model);
            return RedirectToAction("Index");
        }
    }
}