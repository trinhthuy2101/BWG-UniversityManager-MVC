using ASP_NET_MVC.Controllers.Ajax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_NET_MVC.Models;


namespace ASP_NET_MVC.Controllers.UniversityManager
{
    public class AjaxTeacherController : AjaxController
    {
        // GET: AjaxTeacher
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetTimeTable(string id) {
            
            string SQL = "select * from Course where Teacher='" + id + "'";
            return Json(DB.Database.SqlQuery<Course>(SQL).ToList(),JsonRequestBehavior.AllowGet);
        }
    }

}