using Microsoft.AspNetCore.Mvc;
using OnlineTicariOtomasyon.Models.Classes;
using System.Collections;
using System.Web;
using System.Web.Helpers;
namespace OnlineTicariOtomasyon.Controllers
{
    public class GraphicController: Controller
    {
        Context dbcontext = new Context();

        public IActionResult Index()
        {
            return View();
        }
        
    }
}
