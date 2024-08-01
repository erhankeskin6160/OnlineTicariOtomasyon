using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineTicariOtomasyon.Models.Classes;
namespace OnlineTicariOtomasyon.Controllers
{
    public class SalesController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var degerler = context.SalesActivities.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult Newsale()
        {
            List<SelectListItem> selectListItems = (from x in context.Products.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.ProductName,
                                                        Value = x.ProductId.ToString()
                                                    }
                                                 ).ToList();

            List<SelectListItem> selectListItems2 = (from x in context.Currents.ToList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.CurrentName + " " + x.CurrentLastName,
                                                         Value = x.CurrentId.ToString()
                                                     }
                                                ).ToList();

            List<SelectListItem> selectListItems3 = (from x in context.Personels.ToList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.PersonelName + " " + x.Personel_Last_Name,
                                                         Value = x.PersonelId.ToString()
                                                     }


                                                    ).ToList();
            ViewBag.dgr1 = selectListItems;
            ViewBag.dgr2 = selectListItems2;
            ViewBag.dgr3 = selectListItems3;
            return View();
        }
        [HttpPost]
        public IActionResult Newsale(SalesActivity s)
        {
            s.Date = new SalesActivity().Date;
            context.SalesActivities.Add(s);
            //context.Update(s);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSale (int id)
        {
            List<SelectListItem> selectListItems = (from x in context.Products.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.ProductName,
                                                        Value = x.ProductId.ToString()
                                                    }
                                                ).ToList();

            List<SelectListItem> selectListItems2 = (from x in context.Currents.ToList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.CurrentName + " " + x.CurrentLastName,
                                                         Value = x.CurrentId.ToString()
                                                     }
                                                ).ToList();

            List<SelectListItem> selectListItems3 = (from x in context.Personels.ToList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.PersonelName + " " + x.Personel_Last_Name,
                                                         Value = x.PersonelId.ToString()
                                                     }


                                                    ).ToList();
            ViewBag.dgr1 = selectListItems;
            ViewBag.dgr2 = selectListItems2;
            ViewBag.dgr3 = selectListItems3;
            var sales = context.SalesActivities.Find(id);
            return View("EditSale", sales);
        }
        [HttpPost]
        public IActionResult EditSale(SalesActivity editsales) 
        {
            var sales =context.SalesActivities.Where(x=>x.SalesId == editsales.SalesId).FirstOrDefault();
            
            sales.Productid = editsales.Productid;
            sales.Currentid = editsales.Currentid; 
            sales.Personelid = editsales.Personelid;
            sales.Quantity = editsales.Quantity;
            sales.Price = editsales.Price;
            sales.TotalAmount = editsales.TotalAmount;
            sales.Date = editsales.Date;
            context.SaveChanges();
            return RedirectToAction("Index");   
        }
        public IActionResult SalesDetail(int id)
        {
             var salesdetails=context.SalesActivities.Where(x => x.SalesId == id).ToList();
            return View(salesdetails);

        }
    }
}
