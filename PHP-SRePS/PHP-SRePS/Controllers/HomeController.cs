using PHP_SRePS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHP_SRePS.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        // need to move to a sales controller later
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //                                       

        public ActionResult Index()
        {
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
            var items = _context.Items.ToList();

            ViewBag.Message = "Application sales page.";

            return View(items);
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