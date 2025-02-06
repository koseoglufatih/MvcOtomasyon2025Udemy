using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Mvc;

namespace MvcOtomasyon2025Udemy.Controllers
{
    public class QrController : Controller
    {
        // GET: Qr
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string code)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator newcode = new QRCodeGenerator();
                QRCodeGenerator.QRCode karekod = newcode.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap picture = karekod.GetGraphic(10))
                {
                    picture.Save(ms, ImageFormat.Png);
                    ViewBag.karekodimage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                };

            }
            return View();
        }
    }
}