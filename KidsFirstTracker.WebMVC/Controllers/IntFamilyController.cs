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
    public class IntFamilyController : Controller
    {
        // GET: IntFamily
        public ActionResult Index()
        {
            var service = new IntFamilyService();
            var model = service.GetIntFamily();


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
            if (ModelState.IsValid)
            {
                return View(model);
            }
            var service = new IntFamilyService();
            service.CreateIntFamily(model);
            return RedirectToAction("Index");
        }
    }
}