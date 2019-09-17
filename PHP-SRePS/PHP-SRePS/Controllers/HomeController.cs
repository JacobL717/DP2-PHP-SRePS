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
            // need to change once I know what manager role is called
            if (User.IsInRole("Manager") || User.IsInRole("SalesAssistant"))
            {
                return View("Index");
            }
            else
            {
                return View("Unauthorised");
            }
            
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
            if (User.IsInRole("Manager"))
            {
                return View();
            }
            else
            {
                return View("Restricted");
            }
        }
    }
}