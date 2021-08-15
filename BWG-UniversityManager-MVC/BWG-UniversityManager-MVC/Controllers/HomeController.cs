using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC.Controllers
{
    public class HomeController : BaseController
    {

        public ActionResult Index()
        {
            if (LoginModel.Role == "Student")
                return RedirectToAction("Index", "AjaxStudentForStudent");
            else if (LoginModel.Role == "Teacher")
                return RedirectToAction("Index", "AjaxTeacher");
            else if (LoginModel.Role == "Administrator")
                return RedirectToAction("Index", "AjaxAdmin");
            else return View();
        }
    }
}