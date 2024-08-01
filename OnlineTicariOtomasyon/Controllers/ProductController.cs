using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        Context dbcontext= new Context();
        
        public IActionResult Index(string p)
        {
            //var urunler = dbcontext.Products.Where(x=>x.Status==true).ToList();
            var urunler = from c in dbcontext.Products select c;
            if (!string.IsNullOrEmpty(p) )
            {
                urunler = urunler.Where(x => x.ProductName.Contains(p));
            }

            return View(urunler.ToList());

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
        public IActionResult ProductList() 
        {
            var product = dbcontext.Products.ToList();
            return View(product);
        }

        [HttpGet]
        public IActionResult NewSale(int id) 
        {


            List<SelectListItem> selectListItems = (from x in dbcontext.Personels.ToList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.PersonelName + " " + x.Personel_Last_Name,
                                                         Value = x.PersonelId.ToString()
                                                     }


                                                    ).ToList();

            var product=dbcontext.Products.Find(id);
            ViewBag.dgr2 = product.ProductId;
            ViewBag.Price=product.SalePrice;
            ViewBag.personel = selectListItems;
            var maxadet=dbcontext.Products.Where(x=>x.ProductId==id).Max(y=>y.Stock);   
            ViewBag.maxadet = maxadet;
            return View();
        }
        [HttpPost]
        public IActionResult NewSale(SalesActivity p) 
        {
             return View();
            p.Date =DateTime.Now.ToShortDateString();
            ViewBag.date = p.Date;
            dbcontext.SalesActivities.Add(p);
            dbcontext.SaveChanges();
            
        }
    }
}
