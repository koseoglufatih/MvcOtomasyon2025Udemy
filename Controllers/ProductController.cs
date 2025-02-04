using MvcOtomasyon2025Udemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOtomasyon2025Udemy.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        FamuContext _context = new FamuContext();
        public ActionResult Index()
        {
            var products = _context.Products.Where(x => x.Status == true).ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> result1 = (from x in _context.Categorys.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryID.ToString()
                                            }).ToList();
            ViewBag.result1 = result1;
            return View();

        }

        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            _context.Products.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int id)
        {
            var result = _context.Products.Find(id);
            result.Status = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetProduct(int id)
        {

            List<SelectListItem> result1 = (from x in _context.Categorys.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryID.ToString()
                                            }).ToList();
            ViewBag.result1 = result1;
            var productresult = _context.Products.Find(id);

            return View("GetProduct", productresult);
        }

        public ActionResult UpdateProduct(Product p)
        {
            var prd = _context.Products.Find(p.ProductID);
            prd.PurchasePrice = p.PurchasePrice;
            prd.Status = p.Status;
            prd.CategoryID = p.CategoryID;
            prd.Brand = p.Brand;
            prd.SalePrice = p.SalePrice;
            prd.Stock = p.Stock;
            prd.ProductName = p.ProductName;
            prd.ProductImage = p.ProductImage;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductList()
        {
            var result = _context.Products.ToList();
            return View(result);
        }
    }
}