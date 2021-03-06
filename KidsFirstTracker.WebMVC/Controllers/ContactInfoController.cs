using KidsFirstTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidsFirstTracker.WebMVC.Controllers
{
    [Authorize]
    public class ContactInfoController : Controller
    {
        // GET: ContactInfo
        public ActionResult Index()
        {
            var model = new ContactInfoListItem[0];
            return View(model);
        }

        //Get Method for Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactInfoCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}