﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC.Controllers.Ajax
{
    public class AjaxStudentForStudentController : BaseController
    {
        // GET: AjaxStudentForStudent
        public ActionResult Index()
        {
            if (LoginModel.Role == "Student")
                return View();
            else return RedirectToAction("NoPermission", "Base");
        }
    }
}