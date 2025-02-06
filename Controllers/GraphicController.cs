using MvcOtomasyon2025Udemy.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOtomasyon2025Udemy.Controllers
{
    public class GraphicController : Controller
    {
        // GET: Graphic
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[] { "Televizyon", "Beyaz Eşya", "Küçük Ev Aletleri" }, yValues: new[] { 85, 66, 98 }).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");

        }
        FamuContext _context = new FamuContext();
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var result = _context.Products.ToList();
            result.ToList().ForEach(x =>xvalue.Add(x.ProductName));
            result.ToList().ForEach(y =>yvalue.Add(y.Stock));
            var grf = new Chart(1000,1000)
                .AddTitle("Stoklar")
                .AddSeries(chartType:"Column",name:"Stok",xValue:xvalue,yValues:yvalue);
            return File(grf.ToWebImage().GetBytes(),"image/jpeg");
        }

        public ActionResult Index4()
        {
            return View();
        }

        public ActionResult VisualizeProductResult()
        {
            return Json(ProductList(), JsonRequestBehavior.AllowGet);

        }
        public List<Class2> ProductList()
        {
            List<Class2> snf = new List<Class2>();
            snf.Add(new Class2()
            {
                ProductName = "Bilgisayar",
                Stock = 120
            });
            snf.Add(new Class2()
            {
                ProductName = "Beyaz Eşya",
                Stock = 150
            });
            snf.Add(new Class2()
            {
                ProductName = "Küçük Ev Aletleri",
                Stock = 180
            });
            snf.Add(new Class2()
            {
                ProductName = "Mobilya",
                Stock = 70
            });
            snf.Add(new Class2()
            {
                ProductName = "Mobil Cihazlar",
                Stock = 90
            });

            return snf; 
        }

        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeProductResult2()
        {
            return Json(ProductList2(),JsonRequestBehavior.AllowGet);
        }

        public List<Class3> ProductList2()
        {
            List<Class3> snf2 = new List<Class3>();
            using (var context = new FamuContext())
            {
                snf2 = context.Products.Select(x => new Class3
                {
                    Prdct = x.ProductName,
                    Stck = x.Stock
                }).ToList();

            }
            return snf2;
        }

        public ActionResult Index6()
        {

            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
    }

   
}