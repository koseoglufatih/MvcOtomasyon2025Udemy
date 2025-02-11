using MvcOtomasyon2025Udemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOtomasyon2025Udemy.Controllers
{
   
    public class DepartmentController : Controller
    {
        // GET: Department
        FamuContext _context = new FamuContext();
       
        public ActionResult Index()
        {
            var results = _context.Departments.Where(x => x.Status == true).ToList();
            return View(results);
        }

        [HttpGet]

        [Authorize(Roles ="A")]
        public ActionResult AddDepartment()
        {
            return View();
        }



        [HttpPost]
   
        public ActionResult AddDepartment(Department d)
        {
            _context.Departments.Add(d);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteDepartment(int id)
        {
            var dep = _context.Departments.Find(id);
            dep.Status = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetDepartment(int id)
        {

            var dpt = _context.Departments.Find(id);
            return View("GetDepartment", dpt);
        }

        public ActionResult UpdateDepartment(Department d)
        {
            var dpt = _context.Departments.Find(d.DepartmentID);
            dpt.DepartmentName = d.DepartmentName;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentDetail(int id)
        {
            var result = _context.Employees.Where(x => x.DepartmentID == id).ToList();
            var dpt = _context.Departments.Where(x => x.DepartmentID == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.d = dpt;
            return View(result);

        }

        public ActionResult DepartmentEmployeeSales(int id)
        {
            var results = _context.SalesTransactions.Where(x => x.PersonelID == id).ToList();
            var emp = _context.Employees.Where(x => x.PersonelID == id).Select(y => y.PersonelName + " " + y.PersonelSurName).FirstOrDefault(); ;
            ViewBag.dpers = emp;
            return View(results);
        }
    }
}