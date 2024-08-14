using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineTicariOtomasyon.Models.Classes;
using System.Net;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace OnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context context = new Context();

      

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Index(Current current) //Current Login
        {
          var info = context.Currents.FirstOrDefault(x => x.CurrentMail == current.CurrentMail && x.CurrentPassword == current.CurrentPassword);
            if (info != null)
            {
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.Email, current.CurrentMail)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                HttpContext.Session.SetString("CurrentMail", current.CurrentMail);
                var deger=HttpContext.Session.GetString("CurrentMail");
 				return RedirectToAction("Index", "CurrentPanel");
			}
            else
            {
                ViewBag.Error = "Geçersiz kullanıcı adı veya şifre.";
                return RedirectToAction("Index", "Login");
            }

           

		}
        [HttpGet]
        public IActionResult AdminLogin() 
        {             
            return View();
        }
        [HttpPost]
        public IActionResult AdminLogin(Admin admin) 
        {
            var info =context.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, admin.Username)
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();
            var adminrole=context.Admins.FirstOrDefault(x=>x.Username==admin.Username);
            if (info!=null)
            {
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Login"); 
            }
          
        }
        public IActionResult AdminLogout() 
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

        



        [HttpGet]
        public PartialViewResult Partial2()//Register
		{
           var deger= context.Currents.ToList();
            return PartialView();
		}

        [HttpPost]
        public RedirectToActionResult Partial2(Current current) 
        
        {
             

            context.Currents.Add(current);
            context.SaveChanges();

            
             
          return RedirectToAction("Index","Login");
            
        }
        [HttpGet]

        public PartialViewResult Partial3() //Login
        {
            return PartialView();
        }
        [HttpPost]
        public   PartialViewResult Partial3(Current c) 
        {
            var info=context.Currents.FirstOrDefault(x=>x.CurrentMail==c.CurrentMail && x.CurrentPassword==c.CurrentPassword);
           
            

     
    
            return PartialView();
             
             
        }
    }
}
