﻿using Microsoft.Reporting.WebForms;
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
            var sales = _context.SalesTransactions
                                    .SqlQuery("SELECT * FROM SalesTransactions WHERE MONTH(Date)=" + @month)
                                    .ToList();
            //            var sales = _context.SalesTransactions.ToList();
            

            return View(sales);
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