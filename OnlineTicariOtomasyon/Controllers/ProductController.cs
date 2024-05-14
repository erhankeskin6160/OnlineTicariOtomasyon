using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        Context dbcontext= new Context();
        
        public IActionResult Index()
        {
            //var urunler = dbcontext.Products.Where(x=>x.Status==true).ToList();
           var urunler = dbcontext.Products.ToList();   
            return View(urunler);

            ViewBag.product = new List<Product>().ToList();
        }
        
        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> selects = (from x in dbcontext.Categories.ToList()
                                            select new SelectListItem 
                                            { 
                                                Text= x.Name,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();    
            ViewBag.dgr1 = selects;
            return View();
        }            

            [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            
                dbcontext.Products.Add(p);
                dbcontext.SaveChanges();
                
          
            
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(int id) 
        {
            var deleteproduct=dbcontext.Products.Find(id);
            dbcontext.Products.Remove(deleteproduct);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditProduct(int id) 
        {
            var product = dbcontext.Products.Find(id);
            List<SelectListItem> selectListItem = (from x in dbcontext.Categories.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();

            ViewBag.cat = selectListItem;

            return View(product);
        }
        [HttpPost]
        public IActionResult EditProduct(Product p)
        {




            
            var product=dbcontext.Products.Find(p.ProductId);   
            product.ProductName = p.ProductName;
            product.Brand = p.Brand;  
            product.Stock = p.Stock;
            product.PurchasePrice = p.PurchasePrice;
            product.SalePrice = p.SalePrice;
             product.CategoryId = p.CategoryId;
            product.Product_Img = p.Product_Img;
          
            dbcontext.SaveChanges();
          return  RedirectToAction("Index");
        }
    }
}
