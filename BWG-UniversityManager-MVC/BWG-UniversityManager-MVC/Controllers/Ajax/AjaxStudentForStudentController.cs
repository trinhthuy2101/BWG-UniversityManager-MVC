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

            string SQL = "select * from Course,RegisteredCourse where id in (select Course from RegisteredCourse where Student='" + id + "') and student='" + id + "' and course = id";
            return Json(DB.Database.SqlQuery<CourseAndRegisteredCourse>(SQL).ToList(), JsonRequestBehavior.AllowGet);
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
        public ActionResult RegisterToCourse(string course, string keepConflict = "no")
        {
            string accountid = LoginModel.Id;
            string SQLFindTrueID = " select UserName from Account where id = '" + accountid + "'";
            string studentid = DB.Database.SqlQuery<string>(SQLFindTrueID).FirstOrDefault();

            //find registered coursed
            string registeredCourseSQL = "select * from Course where id in (select Course from RegisteredCourse where Student='" + studentid + "')";
            var registeredCourses = DB.Database.SqlQuery<Course>(registeredCourseSQL).ToList();

            string thisCourseSQL = "select * from Course where id ='" + course + "'";

            var thisCourse = DB.Database.SqlQuery<Course>(thisCourseSQL).FirstOrDefault();
            if (thisCourse != null)
            {
                if (registeredCourses.Find(x => x.Date == thisCourse.Date && x.Time == thisCourse.Time) != null)
                {
                    if (keepConflict == "no") return (Json("Time conflict: you cannot register since you already register a course has same time period", JsonRequestBehavior.AllowGet));
                }
            }
            string SQL = "insert into RegisteredCourse values('" + course + "','" + studentid + "',NULL" + ",NULL) ";
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

        public ActionResult PayThisCourse(string student, string course)
        {
            string SQL = "update RegisteredCourse set Fee ='paid' where Course= '" + course + "' and Student='" + student + "'";
            DB.Database.ExecuteSqlCommand(SQL);
            return Json(new object(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult RemoveThisCourse(string student, string course)
        {
            string SQL = "delete from RegisteredCourse where Course= '" + course + "' and Student='" + student + "'";
            DB.Database.ExecuteSqlCommand(SQL);
            return Json(new object(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult PayAllCourse()
        {
            string accountid = LoginModel.Id;
            string SQLFindTrueID = " select UserName from Account where id = '" + accountid + "'";
            string id = DB.Database.SqlQuery<string>(SQLFindTrueID).FirstOrDefault();

            string SQL = "update RegisteredCourse set Fee ='paid' where Student='" + id + "'";
            DB.Database.ExecuteSqlCommand(SQL);
            return Json(new object(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetSumFee()
        {
            string accountid = LoginModel.Id;
            string SQLFindTrueID = " select UserName from Account where id = '" + accountid + "'";
            string id = DB.Database.SqlQuery<string>(SQLFindTrueID).FirstOrDefault();

            string SQL = "select * from subject where id in(select Subject from course where id in(select Course from registeredcourse where Student='" + id + "' and fee is null))";
            var subjects = DB.Database.SqlQuery<Subject>(SQL).ToList();
            int sum = 0;
            foreach (var subject in subjects)
            {
                sum += (int)subject.FeePerCredit * (int)subject.Credits;
            }
            return Json(sum, JsonRequestBehavior.AllowGet);
        }
    }
}