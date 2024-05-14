using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineTicariOtomasyon.Models.Classes;
namespace OnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        Context context= new Context(); 
        public IActionResult Index()
        {
            var personel = context.Personels.ToList();
            return View(personel);
        }
        [HttpGet]
        public IActionResult EditPersonel(int id) 
        {
            var personel = context.Personels.Where(x=>x.PersonelId==id).FirstOrDefault();   

            return View(personel);  
        }

        [HttpPost]
        public IActionResult EditPersonel(Personel p)
        {
            var personel = context.Personels.Where(x => x.PersonelId == p.PersonelId).First();
            personel.PersonelName = p.PersonelName;
            personel.Personel_Last_Name = p.Personel_Last_Name;
            personel.PersoneImage = p.PersoneImage;
            //personel.Department.DepartmentId=p.Department.DepartmentId;
            context.SaveChanges();

            //List<SelectListItem> selectListItems = (from x in context.Departments.ToList()
            //                                        select new SelectListItem { Text = x.DepartmentName, Value = x.DepartmentId.ToString() }).ToList();


            //ViewBag.dep = selectListItems;
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public IActionResult AddPersonel() 
        {
            List<SelectListItem> selectListItems = (from x in context.Departments.ToList()
                                                select new SelectListItem { Text = x.DepartmentName, Value = x.DepartmentId.ToString() }).ToList();
            ViewBag.SelectListItems = selectListItems;
            return View();
        }
        [HttpPost]
        public IActionResult AddPersonel(Personel p) 
        {
            context.Personels.Add(p);
                context.SaveChanges();  
            return RedirectToAction("Index");
        }
        [HttpGet]
        
        public IActionResult PersonelDetails(int id) 
        {

            var prs = context.SalesActivities.Where(x=>x.Personelid == id).ToList();
            ViewBag.d = context.Personels.Where(x => x.PersonelId == id).Select(x => x.PersonelName).First();

            return View(prs);
        }


    }
}
