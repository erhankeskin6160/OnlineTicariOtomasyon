using Microsoft.AspNetCore.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class Gallery : Controller
    {
        Context context = new Context();    
        public IActionResult Index()
        {
          var resimler= context.Products.ToList();
            return View(resimler);
        }
    }
}
