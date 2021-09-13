using ASP_NET_MVC.Controllers.Ajax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_NET_MVC.Models;

namespace ASP_NET_MVC.Controllers.UniversityManager
{
    public class AjaxTeacherController : BaseController
    {
        //TODO: authorize teacher, admin
        //[Authorize(Roles = "HRManager,Finance")]
        public ActionResult Index()
        {
            if (LoginModel.Role == "Teacher")
                return View();
            else return RedirectToAction("NoPermission", "Base");
        }
        /*public ActionResult Logout()
        {
            return View();
        }*/
        public ActionResult GetTimeTable() {
            string accountid = LoginModel.Id;
            string SQLFindTrueID=" select UserName from Account where id = '" + accountid + "'";
            string id = DB.Database.SqlQuery<string>(SQLFindTrueID).FirstOrDefault();

            string SQL = "select * from Course where Teacher='" + id + "'";
            return Json(DB.Database.SqlQuery<Course>(SQL).ToList(),JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetListRegisteredCourseFromRegisteredCourse(string courseid) {

            string accountid = LoginModel.Id;
            string SQLFindTrueID = " select UserName from Account where id = '" + accountid + "'";
            string id = DB.Database.SqlQuery<string>(SQLFindTrueID).FirstOrDefault();
            string SQLCheckSubject = "select * from Course where Teacher='" + id + "' and EndDate IS NOT NULL";
            var subject = DB.Database.SqlQuery<Course>(SQLCheckSubject).ToList();
            if(subject==null) return Json("cannot get", JsonRequestBehavior.AllowGet);


            string SQL = "select RegisteredCourse.Course as Course,RegisteredCourse.Student as Id,RegisteredCourse.Point as Point,Student.Name as Student from webt2289_thuy.RegisteredCourse , webt2289_thuy.Student where Course = '"+ courseid + "' and Student.id = RegisteredCourse.Student ";
            var list = DB.Database.SqlQuery<StudentWithPointAndCourse>(SQL).ToList();
            if (list.Count <= 0||list==null) return Json("cannot get", JsonRequestBehavior.AllowGet);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SavePoints(string id,string point) {
            string SQL= "UPDATE RegisteredCourse  SET Point =" + point+" WHERE Student='"+id+"'";
            DB.Database.ExecuteSqlCommand(SQL);
            return Json(new object(), JsonRequestBehavior.AllowGet);

        }

        //get teacher name
        public ActionResult ReturnName()
        {
            string accountid = LoginModel.Id;
            string SQLFindTrueID = " select UserName from Account where id = '" + accountid + "'";
            string id = DB.Database.SqlQuery<string>(SQLFindTrueID).FirstOrDefault();

            string SQLFindName = "select Name from teacher where id='" + id + "'";
            string name = DB.Database.SqlQuery<string>(SQLFindName).FirstOrDefault();
            return Json(name, JsonRequestBehavior.AllowGet);

        }

    }

}