using System;
using System.Collections.Generic;
using System.Dynamic;
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
            {
                var ViewModel = new ViewModels();
                ViewModel.ViewModelCourse = DB.Courses.ToList();
                ViewModel.ViewModelSubject = DB.Subjects.ToList();
                ViewModel.ViewModelTeacher = DB.Teachers.ToList();
                ViewModel.ViewModelRoom = DB.Rooms.ToList();
                return View(ViewModel);
            }
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

        public ActionResult ShowTeacherList()
        {
            List<Teacher> teachers= DB.Teachers.ToList();
            if (checkRoleLoginModel == "Administrator")
                return View(teachers);
            else if (checkRoleLoginModel == null)
                return RedirectToAction("Login", "Account");
            else
                return RedirectToAction("NoPermission", "Base");
        }

        public ActionResult ShowSubjectList()
        {
            List<Subject> subjects= DB.Subjects.ToList();
            if (checkRoleLoginModel == "Administrator")
                return View(subjects);
            else if (checkRoleLoginModel == null)
                return RedirectToAction("Login", "Account");
            else
                return RedirectToAction("NoPermission", "Base");
        }

        public ActionResult ShowRoomList()
        {
            List<Room> rooms= DB.Rooms.ToList();
            if (checkRoleLoginModel == "Administrator")
                return View(rooms);
            else if (checkRoleLoginModel == null)
                return RedirectToAction("Login", "Account");
            else
                return RedirectToAction("NoPermission", "Base");
        }

        public ActionResult ShowAccountList()
        {
            List<Account> accounts= DB.Accounts.ToList();
            if (checkRoleLoginModel == "Administrator")
                return View(accounts);
            else if (checkRoleLoginModel == null)
                return RedirectToAction("Login", "Account");
            else
                return RedirectToAction("NoPermission", "Base");
        }
        public ActionResult AddCourse(string id,string subject,string teacher,string room,string time)
        {
            var c1 = DB.Courses.Find(id);
            if (c1 != null) return Json(false, JsonRequestBehavior.AllowGet);

            Course c = new Course();
            c.Id = id;
            c.Subject =subject ;
            c.Teacher = teacher;
            c.Room = room;
            c.Time = time;
            var c2 = new CourseModel();
            c2.Id=c.Id;
            c2.Subject=c.Subject;
            c2.Teacher=c.Teacher;
            c2.Room=c.Room;
            c2.Time=c.Time;
            if (ModelState.IsValid)
            {
                DB.Courses.Add(c);
                DB.SaveChanges();
            }
            return Json(c2, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteCourse(string Id)
        {
            Course c = DB.Courses.Find(Id);
            var courseModel = new CourseModel();
            courseModel.Id = c.Id;
            courseModel.Subject = c.Subject;
            courseModel.Teacher = c.Teacher;
            courseModel.Room = c.Room;
            courseModel.Time = c.Time;
            if (ModelState.IsValid)
            {
                DB.Courses.Remove(c);
                DB.SaveChanges();
            }
            return Json(courseModel, JsonRequestBehavior.AllowGet);
        }
    }
}