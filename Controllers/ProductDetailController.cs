using MvcOtomasyon2025Udemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOtomasyon2025Udemy.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        FamuContext _context = new FamuContext();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            //var result1 = _context.Products.Where(x=>x.ProductID == 1).ToList();
            cs.Result1 = _context.Products.Where(x => x.ProductID == 1).ToList();
            cs.Result2 = _context.Details.Where(y => y.DetailID == 1).ToList();
            return View(cs);
        }
    }
}