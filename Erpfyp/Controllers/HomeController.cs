using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Erpfyp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Sale()
        {
            ViewBag.Message = "Your Sale";

            return View();
        }
        [Authorize]
        public ActionResult Order()
        {
            ViewBag.Message = "Order Details";

            return View();
        }
        [Authorize]
        public ActionResult Purchase()
        {
            ViewBag.Message = "Purchase";

            return View();
        }
        [Authorize]
        public ActionResult Cash()
        {
            ViewBag.Message = "Cash In/Out";

            return View();
        }
        [Authorize]
        public ActionResult Reports()
        {
            ViewBag.Message = "Reporting";

            return View();
        }
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "About page.";

            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "contact page.";

            return View();
        }

    }
}