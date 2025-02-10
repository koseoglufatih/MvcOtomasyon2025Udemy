using MvcOtomasyon2025Udemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOtomasyon2025Udemy.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        FamuContext _context = new FamuContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Current c)
        {
            _context.Currents.Add(c);
            _context.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CariLogin1()
        {
            return View();

        }

        [HttpPost]
        public ActionResult CariLogin1(Current p)
        {
            var result = _context.Currents.FirstOrDefault(x => x.CurrentMail == p.CurrentMail && x.CurrentPassword == p.CurrentPassword);
            if (result != null)
            {

                FormsAuthentication.SetAuthCookie(result.CurrentMail, false);
                Session["CurrentMail"] = result.CurrentMail.ToString();
                return RedirectToAction("Index", "CurrentPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");


            }

        }
        [HttpGet]
        public ActionResult AdminLogin()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin a)
        {
            var result = _context.Admins.FirstOrDefault(x => x.AdminName == a.AdminName && x.Password == x.Password);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(result.AdminName, false);
                Session["AdminName"] = result.AdminName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
    }
}
