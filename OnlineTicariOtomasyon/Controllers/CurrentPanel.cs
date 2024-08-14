using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{



	[Authorize]
	public class CurrentPanel : Controller
	{
		Context context = new Context();
		public IActionResult Index()
		{

			var curretmail = HttpContext.Session.GetString("CurrentMail");


			var degerler = context.Currents.Where(x => x.CurrentMail == curretmail).ToList();
			var mailid = context.Currents.Where(x => x.CurrentMail == curretmail).Select(x => x.CurrentId).FirstOrDefault();
			ViewBag.mailid = mailid;
			ViewBag.m = curretmail;
			var totalsales = context.SalesActivities.Where(x => x.Currentid == mailid).Count();
			ViewBag.totalsales = totalsales;
			var totalbuy = context.SalesActivities.Where(x => x.Currentid == mailid).Sum(x => x.TotalAmount);
			ViewBag.totalbuy = totalbuy;
			var totalproduct = context.SalesActivities.Where(x => x.Currentid == mailid).Sum(x => x.Quantity);
			ViewBag.totalproduct = totalproduct;
			List<Message> message = context.Messages.Where((x => x.Receiver == curretmail)).ToList();
			ViewBag.message = message.ToList();
			var user = HttpContext.User.Identity.Name;
			ViewBag.user = user;
			return View(degerler.ToList());
		}
		public IActionResult MyOrder()

		{

			var currentmail = HttpContext.Session.GetString("CurrentMail");
			var id = context.Currents.Where(x => x.CurrentMail == currentmail.ToString()).Select(x => x.CurrentId).FirstOrDefault();
			var myorder = context.SalesActivities.Where(x => x.Currentid == id).ToList();
			return View(myorder);
		}

		public IActionResult Message(int id)
		{

			var curretmail = HttpContext.Session.GetString("CurrentMail");
			var message = context.Messages.Where((x => x.Receiver == curretmail)).ToList();
			var receviermessegecnt = context.Messages.Where(x => x.Receiver == curretmail).OrderBy(x => x.Date).Count().ToString();

			ViewBag.receviermessage = receviermessegecnt;
			var sendermscount = context.Messages.Where(x => x.Sender == curretmail).Count().ToString();
			ViewBag.sendermessage = sendermscount;
			//var receivermessegecnt = context.Messages.Where(x => x.Rec == curretmail).Count().ToString();

			return View(message.ToList());
		}
		public IActionResult SentMessage()
		{
			var curretmail = HttpContext.Session.GetString("CurrentMail");
			var message = context.Messages.Where((x => x.Sender == curretmail)).ToList();
			var sendermscount = context.Messages.Where(x => x.Sender == curretmail).Count().ToString();
			ViewBag.sendermessage = sendermscount;
			var message1 = context.Messages.Where((x => x.Receiver == curretmail)).ToList();
			var receviermessegecnt = context.Messages.Where(x => x.Receiver == curretmail).Count().ToString();
			ViewBag.receviermessage = receviermessegecnt;
			return View(message.ToList());
		}


		[HttpGet]
		public IActionResult NewMessage()
		{
			var curretmail = HttpContext.Session.GetString("CurrentMail");
			var message = context.Messages.Where((x => x.Sender == curretmail)).ToList();
			var sendermscount = context.Messages.Where(x => x.Sender == curretmail).Count().ToString();
			ViewBag.sendermessage = sendermscount;
			var message1 = context.Messages.Where((x => x.Receiver == curretmail)).ToList();
			var receviermessegecnt = context.Messages.Where(x => x.Receiver == curretmail).Count().ToString();
			ViewBag.receviermessage = receviermessegecnt;
			return View();
		}
		[HttpPost]
		public IActionResult NewMessage(Message newmessage)
		{
			var curretmail = HttpContext.Session.GetString("CurrentMail");
			newmessage.Sender = curretmail;
			newmessage.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
			context.Messages.Add(newmessage);
			context.SaveChanges();

			return RedirectToAction("Message");
		}

		public IActionResult MessageDetail(int id)
		{
			var degerler = context.Messages.Where(x => x.MessageID == id).ToList();
			var curretmail = HttpContext.Session.GetString("CurrentMail");
			var message = context.Messages.Where((x => x.Receiver == curretmail)).ToList();
			return View(degerler.ToList());
		}
		public IActionResult CargoTracking(string searchtrckcode)
		{


			var cargo = (from c in context.Cargo select c);


			cargo = cargo.Where(x => x.TrackingCode.Contains(searchtrckcode));

			return View(cargo.ToList());






		}

		public IActionResult Logout()
		{
			var cıkıs = HttpContext.SignOutAsync();
			//HttpContext.Session.Clear();
			return RedirectToAction("Index", "Login");
		}

        public PartialViewResult Profile()
        {
            var mail = HttpContext.Session.GetString("CurrentMail");
            var id = context.Currents.Where(x => x.CurrentMail == mail).Select(x => x.CurrentId).FirstOrDefault();
            var currentid = context.Currents.Find(id);
            return PartialView("Profile", currentid);
        }
		[HttpGet]
		public PartialViewResult EditProfile()
        {
            var mail = HttpContext.Session.GetString("CurrentMail");
            var id = context.Currents.Where(x => x.CurrentMail == mail).Select(x => x.CurrentId).FirstOrDefault();
            var currentid = context.Currents.Find(id);
            return PartialView(currentid);
        }

		[HttpPost]
		public RedirectToActionResult EditProfile(Current current) 
		{
			var mail = HttpContext.Session.GetString("CurrentMail");
			var id = context.Currents.Where(x => x.CurrentMail == mail).Select(x => x.CurrentId).FirstOrDefault();
			var currentid = context.Currents.Find(id);
			currentid.CurrentName = current.CurrentName;
			currentid.CurrentLastName = current.CurrentLastName;
			currentid.CurrentMail = current.CurrentMail;
			currentid.CurrentCity = current.CurrentCity;
			currentid.CurrentPassword = current.CurrentPassword;
			context.SaveChanges();
			return RedirectToAction("Index");

            
        }
    }
}



 