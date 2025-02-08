using MvcOtomasyon2025Udemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOtomasyon2025Udemy.Controllers
{
    public class CurrentPanelController : Controller
    {
        // GET: CurrentPanel
        FamuContext _context = new FamuContext();

        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CurrentMail"];
            var result = _context.Currents.FirstOrDefault(x => x.CurrentMail == mail);
            ViewBag.m = mail;
            return View(result);
        }

        public ActionResult MyOrders()
        {
            var mail = (string)Session["CurrentMail"];
            var id = _context.Currents.Where(x => x.CurrentMail == mail.ToString()).Select(y => y.CurrentID).FirstOrDefault();
            var result = _context.SalesTransactions.Where(x => x.CurrentID == id).ToList();
            return View(result);
        }
        public ActionResult IncomingMessage()
        {
            var messages = _context.Messagess.ToList(); 
            return View(messages);
        }
        //[HttpGet]
        //public ActionResult NewMessage()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult NewMessage()
        //{

        //return View(); 

        //}
    }
}