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
                TempData["SaveResult"] = "Your family was created.";
                return RedirectToAction("Index");
            }

            
            ModelState.AddModelError("", "Your family could not be created.");
            
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateHomeStudyService();
            var model = svc.GetHomeStudyById(id);

            return View(model);
        
        }

        public ActionResult Edit(int id)
        {
            var service = CreateHomeStudyService();
            var detail = service.GetHomeStudyById(id);
            var model =
                new HomeStudyEdit
                {
                    HomeStudyId = detail.HomeStudyId,
                    Parent1Name = detail.Parent1Name,
                    Parent2Name = detail.Parent2Name,
                    TypeOfHomeStudy = detail.TypeOfHomeStudy,
                    Agency = detail.Agency
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HomeStudyEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.HomeStudyId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateHomeStudyService();

            if (service.UpdateHomeStudy(model))
            {
                TempData["SaveResult"] = "Your family was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your family could not be updated.");
            return View(model);

        }

        public ActionResult Delete(int id)
        {
            var svc = CreateHomeStudyService();
            var model = svc.GetHomeStudyById(id);

            return View(model);

        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteHomeStudy(int id)
        {
            var service = CreateHomeStudyService();

            service.DeleteHomeStudy(id);

            TempData["SaveResult"] = "Your family was deleted";

            return RedirectToAction("Index");
        }
        private HomeStudyService CreateHomeStudyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HomeStudyService(userId);
            return service;
        }
    }
}