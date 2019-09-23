﻿using PHP_SRePS.Models;
using PHP_SRePS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PHP_SRePS.Controllers
{
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

        public ActionResult GetPrice(string id)
        {
            if (id != null)
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
        public ActionResult Create(SaleTransactionFormViewModel sale)
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
                sale.SalesTransaction.Date = DateTime.Now;
                //sale.SalesTransaction.Item = _context.Items.Single(i => i.ItemId == sale.SalesTransaction.ItemId);

                _context.SalesTransactions.Add(sale.SalesTransaction);
                _context.SaveChanges();

                return RedirectToAction("New", "Sales");
            }
            catch
            {
                return View("Index", "Home");
            }
            
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
    }
}