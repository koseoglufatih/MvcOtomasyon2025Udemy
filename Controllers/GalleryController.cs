using MvcOtomasyon2025Udemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOtomasyon2025Udemy.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        FamuContext _context = new FamuContext();
        public ActionResult Index()
        {
            var result = _context.Products.ToList();
            return View(result);
        }
    }
}