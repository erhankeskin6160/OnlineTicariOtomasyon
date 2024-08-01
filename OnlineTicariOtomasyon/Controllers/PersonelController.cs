using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using OnlineTicariOtomasyon.Models.Classes;
using Microsoft.AspNetCore.Http;
using NuGet.Packaging.Signing;
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

            var img="";

            if (Request.Form.Files.Count > 0)
            {
                var filename = Path.GetFileNameWithoutExtension(Request.Form.Files[0].FileName);
                var extension = Path.GetExtension(Request.Form.Files[0].FileName).ToLower();
                string path = "wwwroot/css/personel/img/" + filename + extension;
                Stream stream = new FileStream(path, FileMode.Create);
                Request.Form.Files[0].CopyTo(stream);

              img = p.PersoneImage = filename + extension;
            }

                var personel = context.Personels.Where(x => x.PersonelId == p.PersonelId).First();
            personel.PersonelName = p.PersonelName;
            personel.Personel_Last_Name = p.Personel_Last_Name;
            personel.PersoneImage = img;
           
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
            if (Request.Form.Files.Count>0)
            {
                var filename = Path.GetFileNameWithoutExtension(Request.Form.Files[0].FileName);
                var extension = Path.GetExtension(Request.Form.Files[0].FileName).ToLower();
                string path="wwwroot/css/personel/img/"+filename+extension;
                Stream stream=new FileStream(path,FileMode.Create);
                Request.Form.Files[0].CopyTo(stream);
                p.PersoneImage = filename+extension;
            }
            context.Add(p);
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

        public IActionResult PersonelList() 
        {
            var personellist=context.Personels.ToList();
            

            return View(personellist);
        }
    }
}
