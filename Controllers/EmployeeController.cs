using MvcOtomasyon2025Udemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOtomasyon2025Udemy.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        FamuContext _context = new FamuContext();
        public ActionResult Index()
        {
            var result = _context.Employees.ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            List<SelectListItem> result1 = (from x in _context.Departments.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.DepartmentName,
                                                Value = x.DepartmentID.ToString()
                                            }).ToList();
            ViewBag.result1 = result1;

            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee e)
        {
            _context.Employees.Add(e);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult GetEmployee(int id)
        {
            List<SelectListItem> result1 = (from x in _context.Departments.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.DepartmentName,
                                                Value = x.DepartmentID.ToString()
                                            }).ToList();
            ViewBag.result1 = result1;

            var emp = _context.Employees.Find(id);
            return View("GetEmployee", emp);

        }

        public ActionResult UpdateEmployee(Employee emp)
        {
            var emplye = _context.Employees.Find(emp.PersonelID);
            emplye.PersonelName = emp.PersonelName;
            emplye.PersonelSurName = emp.PersonelSurName;
            emplye.EmployeeVisiual = emp.EmployeeVisiual;
            emplye.DepartmentID = emp.DepartmentID;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult PersonelList()
        {
            var query = _context.Employees.ToList();

            return View(query);

        }
    }
}