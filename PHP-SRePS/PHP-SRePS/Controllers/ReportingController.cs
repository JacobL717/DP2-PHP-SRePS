using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.WinForms;
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
            return View();
        }

        public ActionResult DisplayMonthlyReport(int month)
        {
            //var sales = _context.SalesTransactions
            //                        .SqlQuery("SELECT * FROM SalesTransactions WHERE MONTH(Date)=" + @month)
            //                        .ToList();
            //            var sales = _context.SalesTransactions.ToList();

            var sales = _context.SalesTransactions
                .Where(s => s.Date.Month == month)
                .GroupBy(s => s.ItemId)

                // Here you can select the properties you'd like the query to return
                // and input the results into a model/viewModel constructor.
                // Essentially saying "Select this info and store it in a new object"
                // for each item returned by the 'Where' clause above (in our case where month equals inputted month)
                .Select(s => new ReportingItemSummary
                {
                    ItemId = s.Key,
                    Quantity = s.Sum(i => i.Quantity),
                    TotalPrice = s.Sum(i => i.TotalPrice)
                }).ToList();

            var viewModel = new ReportingSummaryViewModel
            {
                ItemSummaries = sales,

                // The items list is passed as part of the viewModel as we need them to access
                // the naming, price, etc of the items within the view
                Items = _context.Items.ToList(),

                // Pass the selected month back to the view in order to use it for
                // the "
                Month = month
            };


            return View(viewModel);
        }
        public ActionResult DisplayMonthlyReport_old()
        {
            var items = _context.Items.ToList();

            return View(items);
        }

        public ActionResult ReportList()
        {
            return View(_context.SalesTransactions.ToList());
        }
        
        public ActionResult Reports(string ReportType)
        {
            LocalReport localreport = new LocalReport();
            localreport.ReportPath = Server.MapPath("~/Reports/SalesReport.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "SalesDataSet";
            reportDataSource.Value = _context.SalesTransactions.ToList();
            localreport.DataSources.Add(reportDataSource);
            string reportType = ReportType;
            string mimeType;
            string encoding;
            string FileNameExtention;
            if (reportType == "Excel")
            {
                FileNameExtention = "xlsx";
            }
            if (reportType == "Word")
            {
                FileNameExtention = "docx";
            }
            else
            {
                FileNameExtention = "jpg";
            }

            string[] streams;
            Warning[] warnings;
            byte[] renderedByte;
            renderedByte = localreport.Render(reportType, "", out mimeType, out encoding, out FileNameExtention, out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment;filename= sales_report." + FileNameExtention);
            return File(renderedByte, FileNameExtention);
           
        }
   
    }
}