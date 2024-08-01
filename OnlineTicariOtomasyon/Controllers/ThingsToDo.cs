using Microsoft.AspNetCore.Mvc;
using OnlineTicariOtomasyon.Migrations;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class ThingsToDo : Controller
    {

        Context context = new Context();
        [HttpGet]
        public IActionResult Index()
        {
         var ThingsToDo=context.ThingsToDo.ToList();
            
             
            
            return View(ThingsToDo);
        }
       
         

        [HttpGet]
        public IActionResult AddThingsToDo()
        {

            var thingsTos= context.ThingsToDo.ToList();
            return View(thingsTos);
        }
        [HttpPost]
        public IActionResult AddThingsToDo(ThingsToDo thingsToDo) 
        {
          context.Add(thingsToDo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
