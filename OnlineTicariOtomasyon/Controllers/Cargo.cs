using Microsoft.AspNetCore.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class Cargo : Controller
    {
          Context dbcontext = new Context();
        public IActionResult Index(string searchtrckcode)
        {
              var cargo = (from c in dbcontext.Cargo select c);
            if (!string.IsNullOrEmpty(searchtrckcode))
            {
                cargo = cargo.Where(x => x.TrackingCode.Contains(searchtrckcode));
            }
            return View(cargo.ToList());
        }
        [HttpGet]
        public IActionResult AddCargo()
        {
           
            
            string[] karakterler= { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            
            Random rnd = new Random();
            string karakter1 = karakterler[rnd.Next(0,9)].ToString();
            string karakter2 = karakterler[rnd.Next(0,9)].ToString();
            string karakter3 = karakterler[rnd.Next(0,9)].ToString();
            int value1= rnd.Next(1, 10);
            int value2= rnd.Next(10, 100);
            int value3= rnd.Next(10, 100);
            string trackingcode=value1.ToString()+karakter1+value2.ToString()+karakter2+value3.ToString()+karakter3;
            ViewBag.cargo = trackingcode;
          
             return View();
        }
        [HttpPost]
        public IActionResult AddCargo(OnlineTicariOtomasyon.Models.Classes.Cargo c)
        {
          
             dbcontext.Cargo.Add(c);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CargoTracking(string id)
        {
            var cargo =dbcontext.CargoTrackings.Where(x => x.TrackingCode == id).ToList();
            return View(cargo);
        }
    }
}
