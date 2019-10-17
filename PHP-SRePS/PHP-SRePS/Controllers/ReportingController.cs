using PHP_SRePS.Models;
using PHP_SRePS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHP_SRePS.Controllers
{
    public class ReportingController : Controller
    {
        private ApplicationDbContext _context;

        public ReportingController()
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
            return View("Index");
        }

        public ActionResult DisplayMonthlyReport()
        {

            var sales = _context.SalesTransactions
                .Where(s => s.Date.Month == 09)
                .GroupBy(s => s.ItemId)
                .Select(s => new { itemId = s.Key, Quantity = s.Count() }).ToList();

            //.Select(q => new { itemId = q.Key, count = q.Count() }).ToList();

            //var viewModel = new SalesReportingViewModel
            //{
            //    GroupedSalesHistory = sales.
            //    Items = _context.Items.ToList()
            //};

            //if ((month >= 1) & (month <= 12))
            //{
            //}
            //else
            //{
            //    month = 10;
            //}
            //var sales = _context.SalesTransactions
            //                        .SqlQuery("SELECT * FROM SalesTransactions WHERE MONTH(Date)=", month)
            //                        .ToList();
            ////            var sales = _context.SalesTransactions.ToList();

            return View(sales);
        }
        public ActionResult DisplayMonthlyReport_old()
        {
            var items = _context.Items.ToList();

            return View(items);
        }
    }
}