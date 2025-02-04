using MvcOtomasyon2025Udemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOtomasyon2025Udemy.Controllers
{
    public class CurrentController : Controller
    {
        // GET: Current
        FamuContext _context = new FamuContext();
        public ActionResult Index()
        {
            var result = _context.Currents.Where(x => x.Status == true).ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddCurrent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCurrent(Current c)
        {
            c.Status = true;
            _context.Currents.Add(c);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCurrent(int id)
        {
            var cr = _context.Currents.Find(id);
            cr.Status = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCurrent(int id)
        {
            var current = _context.Currents.Find(id);
            return View("GetCurrent", current);
        }
        public ActionResult UpdateCurrent(Current c)
        {
            if (!ModelState.IsValid)
            {
                return View("GetCurrent");
            }
            var current = _context.Currents.Find(c.CurrentID);
            current.CurrentName = c.CurrentName;
            current.CurrentSurname = c.CurrentSurname;
            current.CurrentMail = c.CurrentMail;
            current.CurrentMail = c.CurrentMail;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CustomerSale(int id)
        {
            var results = _context.SalesTransactions.Where(x => x.CurrentID == id).ToList();
            var cr = _context.Currents.Where(x => x.CurrentID == id).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.cari = cr;
            return View(results);

        }

    }
}