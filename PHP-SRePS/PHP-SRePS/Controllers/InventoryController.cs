using PHP_SRePS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHP_SRePS.Controllers
{
    public class InventoryController : Controller
    {
        private ApplicationDbContext _context;

        public InventoryController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InventoryList()
        {
            var items = _context.Items.ToList();

            return View(items);
        }

       

        public ActionResult Edit(string id)
        {
            var item = _context.Items.SingleOrDefault(i => i.ItemId == id);

            return View();
        }
    }
}