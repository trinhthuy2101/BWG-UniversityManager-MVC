using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_NET_MVC.Models;

namespace ASP_NET_MVC.Controllers.Ajax
{
    public class AjaxAdminController : BaseController
    {
        // GET: AjaxAdmin
        public ActionResult Index()
        {
            if (LoginModel.Role != "Administrator")
                return RedirectToAction("NoPermission", "AjaxAdmin");
            else
                return View();
        }
        public ActionResult NoPermission()
        {
            return View();
        }
        public ActionResult ShowList()
        {
            List<Course> a =DB.Courses.ToList();
            List<CourseModel> cm = new List<CourseModel>();
            for (int i = 0; i < a.Count; i++)
            {
                cm[i].Id = a[i].Id; cm[i].Room = a[i].Room; cm[i].Teacher = a[i].Teacher; cm[i].Subject = a[i].Subject;
                cm[i].StartDate = a[i].StartDate; cm[i].EndDate = a[i].EndDate; cm[i].Time = a[i].Time;
            }
            
            return Json(cm, JsonRequestBehavior.AllowGet);
        }

    }
}