using ASP_NET_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC.Controllers.Ajax
{
    public class AjaxStudentForStudentController : BaseController
    {
        // TODO: authorize Student

        public ActionResult Index()
        {
            return View();

        }

        //get list course that this teacher is teacher
        public ActionResult GetTimeTable()
        {
            string accountid = LoginModel.Id;
            string SQLFindTrueID = " select UserName from Account where id = '" + accountid + "'";
            string id = DB.Database.SqlQuery<string>(SQLFindTrueID).FirstOrDefault();

            string SQL = "select * from Course where id in (select Course from RegisteredCourse where Student='"+id +"')";
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
            if (registered.Count != 0||registered!=null)
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

            

            string SQL = "insert into RegisteredCourse values('"+course+"','"+studentid+"',NULL) ";
            DB.Database.ExecuteSqlCommand(SQL);
            return (Json("Registered", JsonRequestBehavior.AllowGet));
        }

        ////get list registerdcourses
        //public ActionResult GetListRegisteredCourseFromRegisteredCourse(string courseid)
        //{
        //    string SQL = "select RegisteredCourse.Course as Course,RegisteredCourse.Student as Id,RegisteredCourse.Point as Point,Student.Name as Student from webt2289_thuy.RegisteredCourse , webt2289_thuy.Student where Course = '" + courseid + "' and Student.id = RegisteredCourse.Student";
        //    var list = DB.Database.SqlQuery<StudentWithPointAndCourse>(SQL).ToList();
        //    if (list.Count <= 0) return Json("cannot get", JsonRequestBehavior.AllowGet);
        //    return Json(list, JsonRequestBehavior.AllowGet);
        //}

        ////teacher save  points for student
        //public ActionResult SavePoints(string id, string point)
        //{
        //    string SQL = "UPDATE RegisteredCourse  SET Point =" + point + " WHERE Student='" + id + "'";
        //    DB.Database.ExecuteSqlCommand(SQL);
        //    return Json(new object(), JsonRequestBehavior.AllowGet);

        //}

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
