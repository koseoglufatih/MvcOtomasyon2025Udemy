using MvcOtomasyon2025Udemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOtomasyon2025Udemy.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        FamuContext _context = new FamuContext();

        public ActionResult Index(int pages = 1)
        {
            var result = _context.Categorys.ToList();

            return View(result);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category c)
        {
            _context.Categorys.Add(c);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var ctg = _context.Categorys.Find(id);
            _context.Categorys.Remove(ctg);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCategory(int id)
        {

            var ktg = _context.Categorys.Find(id);
            return View("GetCategory", ktg);
        }

        public ActionResult UpdateCategory(Category c)
        {
            var ktg = _context.Categorys.Find(c.CategoryID);
            ktg.CategoryName = c.CategoryName;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}