using Microsoft.AspNetCore.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class BillsController : Controller
    {
         

        Context dbcontext = new Context();
        public IActionResult Index()
        {
            var fatura = dbcontext.Bills.ToList();
            return View(fatura);
        }

        [HttpGet]
        public IActionResult AddBill()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBill(Bill bill)
        {
            dbcontext.Bills.Add(bill);
          
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult EditBill(int id)
        {
            var bill = dbcontext.Bills.Find(id);
            return View(bill);
        }
        [HttpPost]
        public IActionResult EditBill(Bill bill)
        {
            var bıllıd = dbcontext.Bills.Find(bill.BillId);
            bıllıd.BillId = bill.BillId;
            bıllıd.BillSeriNo = bill.BillSeriNo;
            bıllıd.BillNo = bill.BillNo;
            bıllıd.BillSequenceNo = bill.BillSequenceNo;
            bıllıd.Date = bill.Date;
            bıllıd.TaxAdministration = bill.TaxAdministration;
            bıllıd.Hour = bill.Hour;
            bıllıd.DeliveryPerson = bill.DeliveryPerson;
            bıllıd.Receiver = bill.Receiver;
            
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DetailsBill(int id)
        {
            var item = dbcontext.Bill_Items.Where(x => x.BillId == id).ToList();
            var findid= dbcontext.Bills.Find(id);
            Bill bill = new Bill();
            bill.BillId = findid.BillId;
          
            return View(item);
        }
        [HttpGet]
        public IActionResult InvoiceAddItem()
        {
            return View();
        }
        [HttpPost]
        public IActionResult InvoiceAddItem(Bill_Item bill_Item)
        {
            
            dbcontext.Bill_Items.Add(bill_Item);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
