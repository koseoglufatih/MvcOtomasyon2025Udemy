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

        //[Authorize]
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
            var mail = (string)Session["CurrentMail"];
            var messages = _context.Messagess.Where(x => x.Receiver == mail).OrderByDescending(x=>x.MessageID).ToList();
            var incommessages = _context.Messagess.Count(x=>x.Receiver == mail).ToString();
            ViewBag.d1 = incommessages;
            var sendmessages = _context.Messagess.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = sendmessages;
            return View(messages);
        }

        public ActionResult SendMessage()
        {
            var mail = (string)Session["CurrentMail"];
            var messages = _context.Messagess.Where(x => x.Sender == mail).OrderByDescending(z=>z.MessageID).ToList();
            var incommessages = _context.Messagess.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = incommessages;
            var sendmessages = _context.Messagess.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = sendmessages;
            return View(messages);
        }


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

        public ActionResult ShipmentTracking (string p)
        {
            var shipments = from x in _context.ShipmentDetails select x;
            if (!string.IsNullOrEmpty(p))
            {
                shipments = shipments.Where(y => y.TrackingCode.Contains(p));
            }
            return View(shipments.ToList());
            
        }
    }
}