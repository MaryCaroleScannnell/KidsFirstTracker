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
    public class PreferencesController : Controller
    {
        // GET: 
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PreferenceService(userId);
            var model = service.GetPreferences();
            //var model = new PreferencesListItem[0];
            //return View(model);


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
            if (!ModelState.IsValid) return View(model);

            var service = CreatePreferenceService();


            if (service.CreatePreferences(model))
            {
                TempData["SaveResult"] = "Your preference was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Preference could not be created");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePreferenceService();
            var model = svc.GetPreferenceById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePreferenceService();
            var detail = service.GetPreferenceById(id);
            var model =
                new PreferencesEdit
                {
                    PreferenceId = detail.PreferenceId,
                    DomFamId = detail.DomFamId,
                    GenderPreference = detail.GenderPreference,
                    MinAge = detail.MinAge,
                    MaxAge = detail.MaxAge,
                    RacePreference = detail.RacePreference,
                    AreTheyOkayWithOtherStates = detail.AreTheyOkayWithOtherStates,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PreferencesEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PreferenceId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }
            var service = CreatePreferenceService();

            if (service.UpdatePreferences(model))
            {
                TempData["SaveResults"] = "Your preferences were updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your preferences could not be updated");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreatePreferenceService();
            var model = svc.GetPreferenceById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePreference(int id)
        {
            var service = CreatePreferenceService();

            service.DeletePreferences(id);

            TempData["SaveResult"] = "Your preferences were deleted";

            return RedirectToAction("Index");
        }
        private PreferenceService CreatePreferenceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PreferenceService(userId);
            return service;
        }
    }
}