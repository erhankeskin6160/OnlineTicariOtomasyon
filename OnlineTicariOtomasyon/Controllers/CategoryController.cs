

using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineTicariOtomasyon.Models.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using X.PagedList.Extensions;
using X.Web.PagedList;
namespace OnlineTicariOtomasyon.Controllers
{
    
    public class CategoryController :Controller
    {

        Context dbcontext = new();
        public IActionResult Index(int sayfa=1)
        {
            int pagenum = 13; 
            @ViewBag.PageNumber=sayfa;

            //var categorylist=new List<>. ;
            var category = dbcontext.Categories.ToPagedList(sayfa, pagenum);
            //ViewBag.PageSize = pagenum;
            //ViewBag.TotalPages = category.PageCount;

            return (IActionResult)View(category);
        }
        [System.Web.Mvc.HttpGet]
        public IActionResult CategoryAdd()
        {
            return  View();
        }
     

        [System.Web.Mvc.HttpPost]
        public IActionResult CategoryAdd(Category category)
        
        {
            dbcontext.Categories.Add(category);

       
                dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
       
       public  IActionResult CategoryDelete(int id) 
        {
          var categorydelete= dbcontext.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            dbcontext.Categories.Remove(categorydelete);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        [System.Web.Mvc.HttpGet]
        public IActionResult CategoryEdit(int id)
        {
            var categoryedit = dbcontext.Categories.Find(id);
            
            if (categoryedit==null)
            {
                return  RedirectToAction("Index");

            }
            return View(categoryedit);
        }
        [HttpPost]
        public IActionResult CategoryEdit(Category category) 
        {

           var cat= dbcontext.Categories.Find(category.CategoryId);
            cat.Name = category.Name;
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
     
        }

        
    }
}
