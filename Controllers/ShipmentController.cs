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
        public ActionResult Index()
        {
            var shipments = _context.ShipmentDetails.ToList();
            return View(shipments);
        }

        [HttpGet]
        public ActionResult AddShipment()
        {
            return View();
        }



        [HttpPost]
        public ActionResult AddShipment(ShipmentDetail s)
        {
            _context.ShipmentDetails.Add(s);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}