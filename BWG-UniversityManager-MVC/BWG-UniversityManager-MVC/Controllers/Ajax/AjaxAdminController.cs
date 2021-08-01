using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BWG_UniversityManager_MVC.Models;

namespace BWG_UniversityManager_MVC.Controllers.Ajax
{
    public class AjaxAdminController : AjaxController
    {
        // GET: AjaxAdmin
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult ShowList()
        //{
        //    List<Course> a = DB.Courses.ToList();
        //    List<CourseModel> cm = new List<CourseModel>();
        //    for (int i = 0; i < a.Count; i++)
        //    {
        //        cm[i].Id = a[i].Id; cm[i].Room = a[i].Room; cm[i].Teacher = a[i].Teacher; cm[i].Subject = a[i].Subject;
        //        cm[i].StartDate = a[i].StartDate; cm[i].EndDate = a[i].EndDate; cm[i].Time = a[i].Time;
        //    }

        //    return Json(cm, JsonRequestBehavior.AllowGet);
        //}

    }
}