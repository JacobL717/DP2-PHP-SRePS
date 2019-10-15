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

        public ActionResult New()
        {
            var item = new Item();

            return View("ItemForm", item);
        }
       
        [HttpPost]
        public ActionResult Save(Item item)
        {
            var itemInDb = _context.Items.SingleOrDefault(i => i.ItemId == item.ItemId);

            if(itemInDb == null)
            {
                _context.Items.Add(item);
            }
            else
            {
                itemInDb.ItemId = item.ItemId;
                itemInDb.Name = item.Name;
                itemInDb.Price = item.Price;
                itemInDb.QuantityOnHand = item.QuantityOnHand;
                itemInDb.ItemNotes = item.ItemNotes;
                itemInDb.Tag = item.Tag;
            }

            _context.SaveChanges();

            return RedirectToAction("InventoryList", "Inventory");
        }

        public ActionResult Edit(int id)
        {
            var item = _context.Items.SingleOrDefault(i => i.ItemId == id);

            return View("ItemForm", item);
        }

        public ActionResult Delete(int id)
        {
            var item = _context.Items.SingleOrDefault(i => i.ItemId == id);

            if(item == null)
            {
                return HttpNotFound();
            }

            _context.Items.Remove(item);

            _context.SaveChanges();

            return RedirectToAction("InventoryList", "Inventory");
        }
    }
}