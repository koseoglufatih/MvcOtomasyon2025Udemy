using MvcOtomasyon2025Udemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOtomasyon2025Udemy.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        FamuContext _context = new FamuContext();
        public ActionResult Index()
        {
            var results = _context.SalesTransactions.ToList();
            return View(results);
        }
        [HttpGet]
        public ActionResult AddSales()
        {
            List<SelectListItem> result1 = (from x in _context.Products.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ProductName,
                                                Value = x.ProductID.ToString(),
                                            }).ToList();

            List<SelectListItem> result2 = (from x in _context.Currents.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CurrentName + "" + x.CurrentSurname,
                                                Value = x.CurrentID.ToString(),
                                            }).ToList();
            List<SelectListItem> result3 = (from x in _context.Employees.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.PersonelName + "" + x.PersonelSurName,
                                                Value = x.PersonelID.ToString(),
                                            }).ToList();
            ViewBag.rslt1 = result1;
            ViewBag.rslt2 = result2;
            ViewBag.rslt3 = result3;

            return View();

        }
        [HttpPost]
        public ActionResult AddSales(SalesTransaction s)
        {
            s.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            _context.SalesTransactions.Add(s);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetSales(int id)
        {
            List<SelectListItem> result1 = (from x in _context.Products.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ProductName,
                                                Value = x.ProductID.ToString(),
                                            }).ToList();

            List<SelectListItem> result2 = (from x in _context.Currents.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CurrentName + "" + x.CurrentSurname,
                                                Value = x.CurrentID.ToString(),
                                            }).ToList();
            List<SelectListItem> result3 = (from x in _context.Employees.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.PersonelName + "" + x.PersonelSurName,
                                                Value = x.PersonelID.ToString(),
                                            }).ToList();
            ViewBag.rslt1 = result1;
            ViewBag.rslt2 = result2;
            ViewBag.rslt3 = result3;
            var result = _context.SalesTransactions.Find(id);
            return View("GetSales", result);
        }

        public ActionResult UpdateSales(SalesTransaction s)
        {
            var result = _context.SalesTransactions.Find(s.SalesTransactionId);
            result.CurrentID = s.CurrentID;
            result.Piece = s.Piece;
            result.Price = s.Price;
            result.PersonelID = s.PersonelID;
            result.Date = s.Date;
            result.TotalAmount = s.TotalAmount;
            result.ProductID = s.ProductID;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult SalesDetails(int id)
        {

            var result = _context.SalesTransactions.Where(x => x.SalesTransactionId == id).ToList();
            return View(result);


        }

    }

}
