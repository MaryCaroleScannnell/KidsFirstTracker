using KidsFirstTracker.Models;
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
    public class HomeStudyController : Controller
    {
        // GET: HomeStudy
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HomeStudyService(userId);
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
            if (!ModelState.IsValid) return View(model);
            

            var service = CreateHomeStudyService();

            if (service.CreateHomeStudy(model))
            {
                return RedirectToAction("Index");
            }

            TempData["SaveResult"] = "Your family was created.";
            ModelState.AddModelError("", "Your family could not be created.");
            
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateHomeStudyService();
            var model = svc.GetHomeStudyById(id);

            return View(model);
        
        }

        private HomeStudyService CreateHomeStudyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HomeStudyService(userId);
            return service;
        }
    }
}