using MvcOtomasyon2025Udemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOtomasyon2025Udemy.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        FamuContext _context = new FamuContext();
        public ActionResult Index()
        {
            var list = _context.Invoices.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult AddInvoice()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddInvoice(Invoice i)
        {
            _context.Invoices.Add(i);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetInvoice(int id)
        {
            var invoice = _context.Invoices.Find(id);
            return View("GetInvoice", invoice);
        }

        public ActionResult UpdateInvoice(Invoice i)
        {

            var invoice = _context.Invoices.Find(i.InvoiceID);
            invoice.InvoiceSerialNumber = i.InvoiceSerialNumber;
            invoice.InvoiceSequenceNumber = i.InvoiceSequenceNumber;
            invoice.Hour = i.Hour;
            invoice.Date = i.Date;
            invoice.Deliverer = i.Deliverer;
            invoice.Recipient = i.Recipient;
            invoice.TaxOffice = i.TaxOffice;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult InvoiceItem(int id)
        {
            var result = _context.InvoiceItems.Where(x => x.InvoiceID == id).ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddInvoiceItem()
        {

            return View();
        }

        public ActionResult AddInvoiceItem(InvoiceItem i)
        {
            _context.InvoiceItems.Add(i);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Dynamic()
        {
           
                Class5 cs = new Class5();
                cs.Result1 = _context.Invoices.ToList();
                cs.Result2 = _context.InvoiceItems.ToList();
                return View(cs);
            }

        }
    }

