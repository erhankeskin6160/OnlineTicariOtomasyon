using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
           var Gender = new List<SelectListItem>
            {
                new SelectListItem {Text = "Erkek", Value = "Erkek"},
                new SelectListItem {Text = "Kadın", Value = "Kadın"}
            };
            ViewBag.dgr1 = Gender;
            return View();  
        }
        [HttpPost]
        public IActionResult AddCurrent(Current current)
        {
            current.Durum=true;
            


            if (Request.Form.Files.Count > 0) 
            {
                var filename = Path.GetFileNameWithoutExtension(Request.Form.Files[0].FileName);
                var extension = Path.GetExtension(Request.Form.Files[0].FileName).ToLower();
                var path= "wwwroot/css/current/img/"+filename+extension;
                Stream stream = new FileStream(path, FileMode.Create);
                Request.Form.Files[0].CopyTo(stream);
                current.CurrentImage=filename+extension;    
            }
            else
            {

                if (current.Gender == "Erkek")
                {
                    current.CurrentImage = "default.png";
                }
                else if(current.Gender =="Kadın")
                {
                    current.CurrentImage = "default2.png";
                }
                
            }
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
            var Gender = new List<SelectListItem>
            {
                new SelectListItem {Text = "Erkek", Value = "Erkek"},
                new SelectListItem {Text = "Kadın", Value = "Kadın"}
            };
            ViewBag.dgr1 = Gender;
            return View(editcurrent); 
        }
        [HttpPost]
        public IActionResult EditCurrent(Current EditCurrent)
        {
            var currentedit = dbcontext.Currents.Find(EditCurrent.CurrentId);
            var password = currentedit.CurrentPassword.ToString();
            ViewBag.pass= password;
            //if (!ModelState.IsValid)
            //{
            //    return View("EditCurrent");
            //}
            if (Request.Form.Files.Count > 0) 
            { 
                var filename = Path.GetFileNameWithoutExtension(Request.Form.Files[0].FileName);
            var extension = Path.GetExtension(Request.Form.Files[0].FileName).ToLower();
            var path = "wwwroot/css/current/img/" + filename + extension;
            Stream stream = new FileStream(path, FileMode.Create);
            Request.Form.Files[0].CopyTo(stream);
            currentedit.CurrentImage = filename + extension;
           
            }
            else
            {
                if (EditCurrent.Gender=="Erkek")
                {
                    currentedit.CurrentImage = "default.png";
                }
               else if (EditCurrent.Gender=="Kadın") // "Kadın
                {
                    currentedit.CurrentImage = "default2.png";
                }
            }

            
            currentedit.CurrentName= EditCurrent.CurrentName;
            currentedit.CurrentLastName= EditCurrent.CurrentLastName;
            currentedit.CurrentCity= EditCurrent.CurrentCity;
            currentedit.CurrentMail= EditCurrent.CurrentMail;
            currentedit.Gender = EditCurrent.Gender;

            currentedit.Durum=true;    
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
