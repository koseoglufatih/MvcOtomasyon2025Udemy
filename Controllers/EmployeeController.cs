using MvcOtomasyon2025Udemy.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
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
            if (Request.Files.Count>0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/"+filename+extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                e.EmployeeVisiual = "/Image/" + filename + extension;
            }
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
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                emp.EmployeeVisiual = "/Image/" + filename + extension;
            }

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