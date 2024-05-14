using Microsoft.AspNetCore.Mvc;
using OnlineTicariOtomasyon.Models.Classes;


namespace OnlineTicariOtomasyon.Controllers
{
    public class CurrentController : Controller
    {
        Context dbcontext= new Context();   
        public IActionResult Index()
        {
          var current= dbcontext.Currents.Where(x=>x.Durum==true).ToList();
            return View(current);
        }
        [HttpGet]
        public IActionResult AddCurrent() 
        {
            return View();  
        }
        [HttpPost]
        public IActionResult AddCurrent(Current current)
        {
            current.Durum=true;
            dbcontext.Currents.Add(current);
           
            dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult DeleteCurrent(int id) 
        {
            var currentDelete=dbcontext.Currents.Where(x=>x.CurrentId.Equals(id)).First();
            currentDelete.Durum=false;
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditCurrent(int id) 
        {
            var editcurrent=dbcontext.Currents.FirstOrDefault(x=>x.CurrentId==id);   
            return View(editcurrent); 
        }
        [HttpPost]
        public IActionResult EditCurrent(Current EditCurrent)
        {


            //if (!ModelState.IsValid)
            //{
            //    return View("EditCurrent");
            //}

            var currentedit = dbcontext.Currents.Find(EditCurrent.CurrentId);

            currentedit.CurrentName= EditCurrent.CurrentName;
            currentedit.CurrentLastName= EditCurrent.CurrentLastName;
            currentedit.CurrentCity= EditCurrent.CurrentCity;
            currentedit.CurrentMail= EditCurrent.CurrentMail;
            currentedit.Durum=EditCurrent.Durum;    
            //dbcontext.Currents.Update(currentedit);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
            


            //return RedirectToAction("Index");
        }
        public IActionResult CustomerSales(int id) 
        
        {
         var customersales=   dbcontext.SalesActivities.Where(x => x.Currentid == id).ToList();
            ViewBag.cr= dbcontext.Currents.Where(x => x.CurrentId == id).Select(y => y.CurrentName + " " + y.CurrentLastName).FirstOrDefault();

            return View(customersales);

        }
    }
}
