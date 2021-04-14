using KidsFirstTracker.Models;
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
            var model = new HomeStudyListItem();
            return View(model);
        }
    }
}