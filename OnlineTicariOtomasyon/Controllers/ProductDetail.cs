using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    
    public class ProductDetail : Controller
    {
        Context dbcontext= new Context();
        //public IActionResult Index1()
        //{
        //    var product1 =dbcontext.Products.ToList();
        //    return View(product1);
        //}
    
    public IActionResult Index( )
        {
            Class cs =new Class();
            Product product = new Product();
            cs.Deger1 = dbcontext.Products.Where(x => x.ProductId == 3).ToList();
            cs.Deger2 = dbcontext.ProductDetails.Where(y => y.DetailId == 1).ToList();
            return View(cs);    
        }
    }
}
