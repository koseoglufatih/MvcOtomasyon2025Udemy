using MvcOtomasyon2025Udemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOtomasyon2025Udemy.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        FamuContext _context = new FamuContext();
        public ActionResult Index()
        {
            var result1 = _context.Currents.Count().ToString();
            ViewBag.d1 = result1;
            var result2 = _context.Products.Count().ToString();
            ViewBag.d2 = result2;
            var result3 = _context.Employees.Count().ToString();
            ViewBag.d3 = result3;
            var result4 = _context.Categorys.Count().ToString();
            ViewBag.d4 = result4;
            var result5 = _context.Products.Sum(x => x.Stock).ToString();
            ViewBag.d5 = result5;
            var result6 = (from x in _context.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.d6 = result6;
            var result7 = _context.Products.Count(x => x.Stock <= 20).ToString();
            ViewBag.d7 = result7;
            var result8 = (from x in _context.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = result8;
            var result9 = (from x in _context.Products orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = result9;
            var result10 = _context.Products.Count(x => x.ProductName == "Buzdolabı").ToString();
            ViewBag.d10 = result10;
            var result11 = _context.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.d11 = result11;
            var result12 = _context.Products.GroupBy(x => x.Brand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = result12;
            var result14 = _context.SalesTransactions.Sum(x => x.TotalAmount).ToString();
            ViewBag.d14 = result14;
            var result13 = _context.Products.Where(p => p.ProductID == (_context.SalesTransactions.GroupBy(x => x.ProductID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.ProductName).FirstOrDefault();
            ViewBag.d13 = result13;


            ViewBag.d14 = result14;
            DateTime bugun = DateTime.Today;
            var result15 = _context.SalesTransactions.Count(x => x.Date == bugun).ToString();
            ViewBag.d15 = result15;
            var result16 = _context.SalesTransactions.Where(x => x.Date == bugun).Sum(y => y.TotalAmount).ToString();
            ViewBag.d16 = result16;

            return View();
        }

        public ActionResult SimpleTables()
        {
            var query = from x in _context.Currents
                        group x by x.CurrentCity into g
                        select new ClassGroup
                        {
                            City = g.Key,
                            Count = g.Count()
                        };

            return View(query.ToList());

        }

        public PartialViewResult Partial1()
        {
            var query2 = from x in _context.Employees
                         group x by x.Department.DepartmentName into g
                         select new ClassGroup2
                         {
                             Department = g.Key,
                             Count = g.Count(),
                         };

            return PartialView(query2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var query = _context.Currents.ToList();
            return PartialView(query);
        }
        public PartialViewResult Partial3()
        {
            var query = _context.Products.ToList();
            return PartialView(query);
        }
        public PartialViewResult Partial4()
        {
            var query3 = from x in _context.Products
                         group x by x.Brand into g
                         select new ClassGroup3
                         {
                             Brand = g.Key,
                             Count = g.Count(),
                         };

            return PartialView(query3.ToList());

        }


    }
}