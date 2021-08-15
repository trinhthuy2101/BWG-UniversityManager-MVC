using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_NET_MVC.Models;

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


        //get list course that this teacher is teacher
        public ActionResult GetTimeTable()
        {
            string accountid = LoginModel.Id;
            string SQLFindTrueID = " select UserName from Account where id = '" + accountid + "'";
            string id = DB.Database.SqlQuery<string>(SQLFindTrueID).FirstOrDefault();

            string SQL = "select * from Course where id in (select Course from RegisteredCourse where Student='" + id + "')";
            return Json(DB.Database.SqlQuery<Course>(SQL).ToList(), JsonRequestBehavior.AllowGet); 
        }
        public ActionResult ShowCoursesToRegister()
        {
            string accountid = LoginModel.Id;
            string SQLFindTrueID = " select UserName from Account where id = '" + accountid + "'";
            string id = DB.Database.SqlQuery<string>(SQLFindTrueID).FirstOrDefault();


            string SQL = "select * from Course ";
            var courses = DB.Database.SqlQuery<Course>(SQL).ToList();

            string SQLregisteredCourse = "select * from Course where id in (select Course from RegisteredCourse where Student='" + id + "')";
            var registered = DB.Database.SqlQuery<Course>(SQLregisteredCourse).ToList();
            if (registered.Count != 0 || registered != null)
            {
                for (int i = 0; i < courses.Count; i++)
                {
                    if (registered.FindAll(x => x.Subject == courses[i].Subject).Count != 0)
                    {
                        courses.RemoveAt(i);
                        i--;
                    }
                }
            }
            return Json(courses, JsonRequestBehavior.AllowGet);
        }
        public ActionResult RegisterToCourse(string course)
        {
            string accountid = LoginModel.Id;
            string SQLFindTrueID = " select UserName from Account where id = '" + accountid + "'";
            string studentid = DB.Database.SqlQuery<string>(SQLFindTrueID).FirstOrDefault();



            string SQL = "insert into RegisteredCourse values('" + course + "','" + studentid + "',NULL) ";
            DB.Database.ExecuteSqlCommand(SQL);
            return (Json("Registered", JsonRequestBehavior.AllowGet));
        }

        //get student name
        public ActionResult ReturnName()
        {
            string accountid = LoginModel.Id;
            string SQLFindTrueID = " select UserName from Account where id = '" + accountid + "'";
            string id = DB.Database.SqlQuery<string>(SQLFindTrueID).FirstOrDefault();

            string SQLFindName = "select Name from Student where id='" + id + "'";
            string name = DB.Database.SqlQuery<string>(SQLFindName).FirstOrDefault();
            return Json(name, JsonRequestBehavior.AllowGet);

        }

    }
}