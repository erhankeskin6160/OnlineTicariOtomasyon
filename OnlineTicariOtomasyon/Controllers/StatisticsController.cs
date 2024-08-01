using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using OnlineTicariOtomasyon.Controllers;
using OnlineTicariOtomasyon.Models.Classes;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace OnlineTicariOtomasyon.Controllers
{
    public class StatisticsController : Controller
    {
        Context dbcontext= new Context();   
        public IActionResult Index()
        {
            var cariler=dbcontext.Currents.Count().ToString();
            ViewBag.d1=cariler;
            var urunsayısı=dbcontext.Products.Count().ToString();
            ViewBag.d2=urunsayısı;
            var personelsayısı=dbcontext.Personels.Count().ToString();
            ViewBag.d3=personelsayısı;
            var kategorisayısı=dbcontext.Categories.Count().ToString();
            ViewBag.d4=kategorisayısı;
            var toplamstok=dbcontext.Products.Sum(x=>x.Stock).ToString();
            ViewBag.d5=toplamstok;
            var markasayısı=dbcontext.Products.Select(x=>x.Brand).Distinct().Count().ToString();   
            ViewBag.d6=markasayısı;
            var kritikstok=dbcontext.Products.Count(x=>x.Stock<=20).ToString();
            ViewBag.d7=kritikstok;
            var maxfiyat = dbcontext.Products.Max(x => x.SalePrice).ToString();
            /*dbcontext.Products.Select(x=>x.SalePrice).OrderByDescending(x=>x).FirstOrDefault().ToString();*/

            ViewBag.d8=maxfiyat;
            var minfiyat=dbcontext.Products.Min(x=>x.SalePrice).ToString();
            ViewBag.d9=minfiyat;
            var maxmarka=dbcontext.Products.GroupBy(x=>x.Brand).OrderByDescending(x=>x.Count()).Select(x=>x.Key).FirstOrDefault().ToString(); 
            ViewBag.d10=maxmarka;
            var buzdolabısayısı = dbcontext.Categories.Where(x => x.Name == "Bilgisayar").Count().ToString();
            ViewBag.d11=buzdolabısayısı;
          
            var laptop =dbcontext.Products.Where(x=>x.ProductName.Contains("Laptop")).Count().ToString();
            ViewBag .d12=laptop;
            var encoksatan = dbcontext.SalesActivities.Where(x => x.Productid == (dbcontext.SalesActivities.GroupBy(x=>x.Productid).OrderByDescending(x=>x.Count()).Select(x=>x.Key).FirstOrDefault())).Select(x=>x.Product.ProductName).FirstOrDefault();  
            ViewBag.d13 = encoksatan;
 
            var toplamkasa =dbcontext.SalesActivities.Sum(x=>x.TotalAmount).ToString();  
            ViewBag.d14=toplamkasa;
             
            string bugun = DateTime.Now.ToShortDateString();
            var bugunsatis = dbcontext.SalesActivities.Count(x => x.Date == bugun).ToString();
            ViewBag.d15 = bugunsatis;
            var bugunkasa=dbcontext.SalesActivities.Where(x=>x.Date== bugun).Sum(x=>(decimal? )x.TotalAmount).ToString();  
            ViewBag.d16=bugunkasa;  
         


            return View();
        }
        public IActionResult SimpleTables()
        {
            int sa=default;
            var s = from x in dbcontext.Currents group x by x.CurrentCity into g select new ClassGroup
            {
                Sehir = g.Key,
                Sayı = g.Count()
             
            };

             
        
            return View(s);

            
        }
         
        public PartialViewResult Partial1() 
        {
            
             var sorgu = from x in dbcontext.Currents group x by x.CurrentCity into d select new ClassGroup2 { Departman = d.Key, Sayı = d.Count() };
       
            return PartialView(sorgu.ToList());
            
        }
    }
}


