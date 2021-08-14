using ASP_NET_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Account model)
        {
            var account = DB.Accounts.SingleOrDefault(a => a.Password == model.Password && a.UserName == model.UserName);
            if (!ModelState.IsValid || account == null)
            {
                return RedirectToAction("LogginFail", "Account");
            }
                
            LoginModel.Id = account.Id;
            string page = "Ajax";
            if (account.Id == "1")
            {
                LoginModel.Role = "Administrator";
                page += "Admin";
            }
                
            else if (account.UserName.Contains("GV"))
            {
                LoginModel.Role = "Teacher";
                page += "Teacher";
            }
                
            else if (account.UserName.Contains("ST"))
            {
                LoginModel.Role = "Student";
                page +="StudentForStudent";
            }
                
            return RedirectToAction("Index", page);
        }

        public ActionResult LogginFail()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            /*if(LoginModel.Role=="Student")
                return RedirectToAction("Logout", "AjaxStudentForStudent");
            else if (LoginModel.Role == "Teacher")
                return RedirectToAction("Logout", "AjaxTeacher");
            else
                return RedirectToAction("Logout", "AjaxAdmin");*/
            return View();
        }

        [HttpPost]
        public ActionResult Logout(string dummuy)
        {
            LoginModel.Role = null;
            LoginModel.Id = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            if (LoginModel.Id == null)
                return RedirectToAction("NoLoggedAccount", "Account");
            var account = DB.Accounts.SingleOrDefault(a => a.Id == LoginModel.Id);
            return View(account);
        }

        [HttpPost]
        public ActionResult ChangePassword(Account account)
        {
            if (!ModelState.IsValid)
                return View();
            var accountInDb = DB.Accounts.SingleOrDefault(a => a.Id == account.Id);
            accountInDb.Password = account.Password;
            DB.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult NoLoggedAccount()
        {
            return View();
        }
    }
}