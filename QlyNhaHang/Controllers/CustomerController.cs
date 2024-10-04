using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QlyNhaHang.Models;

namespace QlyNhaHang.Controllers
{
    public class CustomerController : Controller
    {
        DienThoaiEntities1 db=new DienThoaiEntities1 ();
        // GET: Customer
        public ActionResult DanhSachKhachHang()
        {
            return View(db.Customer.ToList());
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Customer cus) 
        {
            if (db.Customer.Any(x => x.UserName == cus.UserName))
            {
                ViewBag.Notification = "This account already exist";
                return View();
            }
            else
            {
                db.Customer.Add(cus);
                db.SaveChanges();

                Session["IDCuss"]=cus.IDCus.ToString();
                Session["UsernameSS"] =cus.UserName.ToString();
                return RedirectToAction("Home","Home");

            }
            
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Customer cus)
        {
            var checklogin = db.Customer.Where(x => x.UserName.Equals(cus.UserName) && x.Password.Equals(cus.Password)).FirstOrDefault();    
            if (checklogin != null)
            {
                Session["IdCussSS"] = cus.IDCus.ToString();
                Session["UsernameSS"] =cus.UserName.ToString() ;
                return RedirectToAction("Home","Home");  
            }
            else
            {
                ViewBag.Notification = "Wrong UserName or Password";
            }
            return View();
        }
        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("Home", "Home");
        }
    }
}