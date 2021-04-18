using KidsFirstTracker.Models;
using KidsFirstTracker.Services;
using Microsoft.AspNet.Identity;
using System;
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

        public ActionResult Details(int id)
        {
            var svc = CreateDomFamilyService();
            var model = svc.GetDomFamilyById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateDomFamilyService();
            var detail = service.GetDomFamilyById(id);
            var model =
                new DomFamilyEdit
                {
                    DomFamId = detail.DomFamId,
                    Parent1Name = detail.Parent1Name,
                    Parent2Name = detail.Parent2Name,
                    IsHomeStudyDone = detail.IsHomeStudyDone
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DomFamilyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.DomFamId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }
            var service = CreateDomFamilyService();

            if (service.UpdateDomFamily(model))
            {
                TempData["SaveResults"] = "Your family was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your family could not be updated");
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