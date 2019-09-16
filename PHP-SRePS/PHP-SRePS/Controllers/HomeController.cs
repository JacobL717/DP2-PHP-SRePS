using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHP_SRePS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sales()
        {
            ViewBag.Message = "Application sales page.";

            return View();
        }

        public ActionResult Inventory()
        {
            ViewBag.Message = "Application inventory page.";

            return View();
        }

        public ActionResult Reporting()
        {
            ViewBag.Message = "Application reporting page.";

            return View();
        }
    }
}