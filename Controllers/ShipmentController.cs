using MvcOtomasyon2025Udemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOtomasyon2025Udemy.Controllers
{
    public class ShipmentController : Controller
    {
        // GET: Shipment
        FamuContext _context = new FamuContext();
        public ActionResult Index(string p)
        {
            var shipments = from x in _context.ShipmentDetails select x;
            if (!string.IsNullOrEmpty(p))
            {
                shipments = shipments.Where(y => y.TrackingCode.Contains(p));
            }
            return View(shipments.ToList());
        }

        [HttpGet]
        public ActionResult AddShipment()
        {
            Random rnd = new Random();
            string[] characters = { "A","B","C","D","E","F","G","H","K"};
            int c1, c2, c3;
            c1=rnd.Next(0,characters.Length);
            c2=rnd.Next(0,characters.Length);
            c3 = rnd.Next(0,characters.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000); //10--> 3 1 2 1 2 1
            s2 = rnd.Next(10,99);
            s3 = rnd.Next(10,99);
            string  code = s1.ToString() + characters[c1] + s2 + characters[c2] + s3 + characters[c3];
            ViewBag.code = code;

            return View();
        }

        [HttpPost]
        public ActionResult AddShipment(ShipmentDetail s)
        {
            _context.ShipmentDetails.Add(s);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ShipmentTracking(string id)
        {
            //p = "ABC34598NK";
            var result = _context.ShipmentTrackings.Where(x => x.TrackingCode == id).ToList();
          
            return View(result);

        }



    }
}