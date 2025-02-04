using MvcOtomasyon2025Udemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOtomasyon2025Udemy.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDo
        FamuContext _context = new FamuContext();
        public ActionResult Index()
        {
            var result1 = _context.Currents.Count().ToString();
            ViewBag.r1 = result1;
            var result2 = _context.Products.Count().ToString();
            ViewBag.r2 = result2;
            var result3 = _context.Categorys.Count().ToString();
            ViewBag.r3 = result3;
            var result4 = (from x in _context.Currents select x.CurrentCity).Distinct().Count().ToString();
            ViewBag.r4 = result4;
            var todo = _context.ToDos.ToList();
            return View(todo);
        }
    }
}