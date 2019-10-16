using PHP_SRePS.Models;
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
            return View();
        }

        public ActionResult DisplayMonthlyReport(int month)
        {
            if ((month >= 1) & (month <= 12))
            {
            }
            else
            {
                month = 10;
            }
            var sales = _context.SalesTransactions
                                    .SqlQuery("SELECT * FROM SalesTransactions WHERE MONTH(Date)=", month)
                                    .ToList();
            //            var sales = _context.SalesTransactions.ToList();

            return View(sales);
        }
        public ActionResult DisplayMonthlyReport_old()
        {
            var items = _context.Items.ToList();

            return View(items);
        }
    }
}