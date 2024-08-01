using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
 
using System.Drawing.Imaging;
namespace OnlineTicariOtomasyon.Controllers
 
{
    public class QR: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string id)
        {
            using (MemoryStream memory=new MemoryStream()) 
            {
                QRCodeGenerator codeGenerator = new QRCodeGenerator();
                QRCodeGenerator.QRCode qRCode= codeGenerator.CreateQrCode(id, QRCodeGenerator.ECCLevel.Q);

                using (Bitmap bitmap =qRCode.GetGraphic(10))
                {
                    bitmap.Save(memory, ImageFormat.Png);
                    ViewBag.karedkod = "data:/Image/png;base64," + Convert.ToBase64String(memory.ToArray());
                }
            }

                return View();
        }
    }
}
