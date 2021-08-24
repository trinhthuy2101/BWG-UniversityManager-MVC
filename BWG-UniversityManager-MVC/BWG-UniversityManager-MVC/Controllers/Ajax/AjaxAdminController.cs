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
        /*public ActionResult NoPermission()
        {
            return View();
        }*/
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
    }
}