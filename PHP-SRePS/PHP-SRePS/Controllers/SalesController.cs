using PHP_SRePS.Models;
using PHP_SRePS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHP_SRePS.Controllers
{
    [Authorize]
    public class SalesController : Controller
    {
        private ApplicationDbContext _context;

        // need to move to a sales controller later
        public SalesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var items = _context.Items.ToList();
            var viewModel = new SaleTransactionFormViewModel
            {
                SalesTransaction = new SalesTransaction(),
                Items = items
            };

            return View("SaleTransactionForm", viewModel);
        }

        public ActionResult GetPrice(int id)
        {
            if (id != 0)
            {
                var item = _context.Items.SingleOrDefault(i => i.ItemId == id);

                if (item != null)
                {
                    return Json(new { Success = "true", Data = new { Price = item.Price } });
                }
            }

            return Json(new { Success = "false" });
        }

        [HttpPost]
        public ActionResult Save(SaleTransactionFormViewModel sale)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new SaleTransactionFormViewModel
                {
                    Items = _context.Items.ToList(),
                    SalesTransaction = sale.SalesTransaction
                };

                return View("New", viewModel);
            }

            try
            {
                if (sale.SalesTransaction.Id == 0)
                {
                    sale.SalesTransaction.Date = DateTime.Now;
                    _context.SalesTransactions.Add(sale.SalesTransaction);

                    var itemInTx = _context.Items.Single(i => i.ItemId == sale.SalesTransaction.ItemId);

                    itemInTx.QuantityOnHand -= sale.SalesTransaction.Quantity;
                }
                else
                {
                    var saleInDb = _context.SalesTransactions.Single(s => s.Id == sale.SalesTransaction.Id);

                    saleInDb.Item = sale.SalesTransaction.Item;
                    saleInDb.ItemId = sale.SalesTransaction.ItemId;
                    saleInDb.Notes = sale.SalesTransaction.Notes;
                    saleInDb.Quantity = sale.SalesTransaction.Quantity;
                    saleInDb.TotalPrice = sale.SalesTransaction.TotalPrice;
                }                
            }
            catch
            {
                return View("SalesHistory", "Sales");
            }

            _context.SaveChanges();

            return RedirectToAction("SalesHistory", "Sales");
        }

        public ActionResult Edit(int id)
        {
            var salesTransaction = _context.SalesTransactions.SingleOrDefault(s => s.Id == id);

            if (salesTransaction == null)
            {
                return HttpNotFound();
            }

            var viewModel = new SaleTransactionFormViewModel
            {
                SalesTransaction = salesTransaction,
                Items = _context.Items.ToList()
            };

            return View("SaleTransactionForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var salesTransaction = _context.SalesTransactions.SingleOrDefault(s => s.Id == id);

            if(salesTransaction == null)
            {
                return HttpNotFound();
            }

            _context.SalesTransactions.Remove(salesTransaction);

            _context.SaveChanges();

            return RedirectToAction("SalesHistory", "Sales");
        }

        public ActionResult SalesHistory()
        {
            var viewModel = new TransactionHistoryViewModel
            {
                SalesTransactions = _context.SalesTransactions.ToList(),
                Items = _context.Items.ToList()
            };

            
            ViewBag.Message = "Application sales history page.";

            return View(viewModel);
        }
    }
}