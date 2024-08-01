using Microsoft.AspNetCore.Mvc;
using OnlineTicariOtomasyon.Models.Classes;
using PagedList;


namespace OnlineTicariOtomasyon.Controllers
{
    
    public class CategoryController : Controller
    {

        Context dbcontext = new();
        public IActionResult Index(int sayfa=1)
        {
            int pagenum = 13; 
            @ViewBag.PageNumber=sayfa;
                
            //var categorylist=new List<>. ;
           var  category = dbcontext.Categories.ToList().ToPagedList(sayfa,pagenum);
            ViewBag.PageSize = pagenum;
            ViewBag.TotalPages = category.PageCount;

            return View(category);
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
     

        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        
        {
            dbcontext.Categories.Add(category);

       
                dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
       
       public  ActionResult CategoryDelete(int id) 
        {
          var categorydelete= dbcontext.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            dbcontext.Categories.Remove(categorydelete);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CategoryEdit(int id)
        {
            var categoryedit = dbcontext.Categories.Find(id);
            
            if (categoryedit==null)
            {
                return RedirectToAction("Index");

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
