using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    [Authorize(Roles ="User")]

    public class DepartmentController: Controller
    {
       
        
        Context dbcontext = new Context();
        public IActionResult Index()
        {
            var departmen = dbcontext.Departments.Where(x=>x.Durum==true).ToList<Department>();
            return View(departmen);
        }
       
        [HttpGet]
        public IActionResult AddDepartment() 
        
        {
            return View();  
        }
        [HttpPost]
        public IActionResult AddDepartment(Department department) 
        {

            dbcontext.Add(department);
            dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult DeleteDepartment(int id) 
        { 
             var deletedepertment =dbcontext.Departments.Where(x=>x.DepartmentId==id).FirstOrDefault();
            dbcontext.Remove(deletedepertment);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public IActionResult EditDepartment(int id)
        {
            
           var dep= dbcontext.Departments.Where(x=>x.DepartmentId==id).FirstOrDefault();   
           
           
            return View(dep);
        }
        [HttpPost]
        public IActionResult EditDepartment(Department d) 
        {
            var dp = dbcontext.Departments.Find(d.DepartmentId);
            dp.DepartmentName=d.DepartmentName;
           
     
            dbcontext.SaveChanges( );





            //var categoryedit = dbcontext.Categories.Find(category.CategoryId);

            //categoryedit.Name = category.Name;
            //dbcontext.Categories.Update(categoryedit);
            //dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DepartmentDetail(int id)
        {
            var d_details =dbcontext.Personels.Where(x=>x.Departmentid == id).ToList();
            var dpt=dbcontext.Departments.Where(x=>x.DepartmentId==id).Select(d=>d.DepartmentName).First();
            ViewBag.d = dpt;
            return View(d_details);
             
        }
        public IActionResult DepartmentPersonelSales(int id) 
        {
           var d_sales_actvy=dbcontext.SalesActivities.Where(x=>x.Personelid == id).ToList();
            var personel_name=dbcontext.Personels.Where(x=>x.PersonelId==id).Select(p=> p.PersonelName + " " + p.Personel_Last_Name).FirstOrDefault();
            ViewBag.p=personel_name;
            return View(d_sales_actvy);
        }
    }
}
