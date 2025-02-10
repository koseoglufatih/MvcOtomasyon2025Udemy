using MvcOtomasyon2025Udemy.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOtomasyon2025Udemy.Controllers
{
    public class CurrentPanelController : Controller
    {
        // GET: CurrentPanel
        FamuContext _context = new FamuContext();

        public ActionResult Index()
        {
            var mail = (string)Session["CurrentMail"];
            var result = _context.Messagess.Where(x => x.Receiver == mail).ToList();
            ViewBag.m = mail;
            var mailid=_context.Currents.Where(x=>x.CurrentMail==mail).Select(y=>y.CurrentID).FirstOrDefault();
            ViewBag.mid=mailid;
            var totalsales = _context.SalesTransactions.Where(x => x.CurrentID == mailid).Count();
            ViewBag.total = totalsales;
            var totalamount = _context.SalesTransactions.Where(x => x.CurrentID == mailid).Sum(y => y.TotalAmount);
            ViewBag.totalamount = totalamount;
            var totalproductscount = _context.SalesTransactions.Where(x => x.CurrentID == mailid).Sum(y => y.Piece);
            ViewBag.totalproducts = totalproductscount;
            var namesurname = _context.Currents.Where(x => x.CurrentMail == mail).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.namesurname = namesurname;
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
            var mail = (string)Session["CurrentMail"];
            var messages = _context.Messagess.Where(x => x.Receiver == mail).OrderByDescending(x => x.MessageID).ToList();
            var incommessages = _context.Messagess.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = incommessages;
            var sendmessages = _context.Messagess.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = sendmessages;
            return View(messages);
        }

        [Authorize]
        public ActionResult SendMessage()
        {
            var mail = (string)Session["CurrentMail"];
            var messages = _context.Messagess.Where(x => x.Sender == mail).OrderByDescending(z => z.MessageID).ToList();
            var incommessages = _context.Messagess.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = incommessages;
            var sendmessages = _context.Messagess.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = sendmessages;
            return View(messages);
        }

        [Authorize]
        public ActionResult MessageDetail(int id)
        {
            var result = _context.Messagess.Where(x => x.MessageID == id).ToList();
            var mail = (string)Session["CurrentMail"];
            var incommessages = _context.Messagess.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = incommessages;
            var sendmessages = _context.Messagess.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = sendmessages;
            return View(result);
        }
        [Authorize]
        [HttpGet]
        public ActionResult NewMessage()
        {
            var mail = (string)Session["CurrentMail"];
            var incommessages = _context.Messagess.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = incommessages;
            var sendmessages = _context.Messagess.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = sendmessages;
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Messages m)
        {
            var mail = (string)Session["CurrentMail"];
            m.DateTime = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Sender = mail;
            _context.Messagess.Add(m);
            _context.SaveChanges();
            return View();

        }

        public ActionResult ShipmentTracking(string p)
        {
            var shipments = from x in _context.ShipmentDetails select x;
            shipments = shipments.Where(y => y.TrackingCode.Contains(p));
            return View(shipments.ToList());
        }
        public ActionResult CurrentShipmentTracking(string id)
        {
            var result = _context.ShipmentTrackings.Where(x => x.TrackingCode == id).ToList();
            return View(result);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }

        public PartialViewResult Partial1()
        {
            var mail = (string)Session["CurrentMail"];
            var id = _context.Currents.Where(x => x.CurrentMail == mail).Select(y => y.CurrentID).FirstOrDefault();
            var currentfind = _context.Currents.Find(id);
            return PartialView("Partial1", currentfind);
            

        }
    }
}