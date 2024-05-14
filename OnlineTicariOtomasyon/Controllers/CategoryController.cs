using Microsoft.AspNetCore.Mvc;
using OnlineTicariOtomasyon.Models.Classes;


namespace OnlineTicariOtomasyon.Controllers
{
    
    public class CategoryController : Controller
    {

        Context dbcontext = new();
        public IActionResult Index()
        {
            
            //var categorylist=new List<>. ;
            List<Category> category = dbcontext.Categories.ToList();  
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
            return View(categoryedit);
            if (categoryedit==null)
            {
                return RedirectToAction("Index");

            }

        }
        [HttpPost]
        public IActionResult CategoryEdit(Category category) 
        {
           var categoryedit=dbcontext.Categories.Find(category.CategoryId);

            categoryedit.Name = category.Name;
            dbcontext.Categories.Update(categoryedit);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
