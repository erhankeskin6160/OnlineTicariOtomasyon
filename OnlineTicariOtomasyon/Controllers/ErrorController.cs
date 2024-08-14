using Microsoft.AspNetCore.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult PageEror()
        {
            Response.AppendTrailer("PageEror", "Sayfa Bulunamadı");
            
            return View();
        }
        public IActionResult Page404() 
        {
            Response.StatusCode=404;
            return View(PageEror());
        }
        public IActionResult Page403() 
        {
            Response.StatusCode=403;
            return View(PageEror());
        }
    }
}
