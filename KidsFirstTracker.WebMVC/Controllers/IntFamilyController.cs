using KidsFirstTracker.Models;
using KidsFirstTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace KidsFirstTracker.WebMVC.Controllers
{
    [Authorize]
    public class IntFamilyController : Controller
    {
        // GET: IntFamily
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new IntFamilyService(userId);
            var model = service.GetIntFamily();
           // var model = new IntFamilyListItem[0];

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IntFamilyCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateIntFamilyService();

            if (service.CreateIntFamily(model))
            {
                TempData["SaveResult"] = "Your family was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your family could not be created.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateIntFamilyService();
            var model = svc.GetIntFamilyById(id);

            return View(model);
        
        }

        public ActionResult Edit(int id)
        {
            var service = CreateIntFamilyService();
            var detail = service.GetIntFamilyById(id);
            var model =
                new IntFamilyEdit
                {
                    IntFamId = detail.IntFamId,
                    Parent1Name = detail.Parent1Name,
                    Parent2Name = detail.Parent2Name,
                    Country = detail.Country
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IntFamilyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.IntFamId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateIntFamilyService();

            if (service.UpdateIntFamily(model))
            {
                TempData["SaveResult"] = "Your family was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your family could not be updated");
            return View(model);
        }
        
        private IntFamilyService CreateIntFamilyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new IntFamilyService(userId);
            return service;
        }
    }
}