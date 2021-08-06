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
        public ActionResult Login(AccountModel model)
        {
            var account = DB.Accounts.SingleOrDefault(a => a.Password == model.Password && a.UserName == model.UserName);
            if (!ModelState.IsValid || account == null)
            {
                return View();
            }
            return RedirectToAction("Index", "AjaxStudent");
        }
    }
}