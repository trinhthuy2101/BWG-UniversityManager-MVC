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
                ViewModel.ViewModelAccount = DB.Accounts.ToList();
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
        public ActionResult AddCourse(string id,string subject,string teacher,string room,string time,DateTime startDate, DateTime endDate,string status,String date)
        {
            var c1 = DB.Courses.Find(id);
            if (c1 != null) return Json(false, JsonRequestBehavior.AllowGet);

            Course c = new Course();
            c.Id = id;
            c.Subject =subject ;
            c.Teacher = teacher;
            c.Room = room;
            c.Time = time;
            c.StartDate = startDate;
            c.EndDate = endDate;
            c.Status = status;
            c.Date = date;

            var c2 = new CourseModel();
            c2.Id=c.Id;
            c2.Subject=c.Subject;
            c2.Teacher=c.Teacher;
            c2.Room=c.Room;
            c2.Time=c.Time;
            c2.StartDate=c.StartDate ;
            c2.EndDate= c.EndDate;
            c2.Status = c.Status;
            c2.Date = c.Date;
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
            courseModel.StartDate = c.StartDate;
            courseModel.EndDate = c.EndDate;
            courseModel.Status = c.Status;
            courseModel.Date = c.Date;
            if (ModelState.IsValid)
            {
                DB.Courses.Remove(c);
                DB.SaveChanges();
            }
            return Json(courseModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddRoom(string id, string status, string manager)
        {
            var c1 = DB.Rooms.Find(id);
            if (c1 != null) return Json(false, JsonRequestBehavior.AllowGet);

            Room s = new Room();
            s.Id = id;
            s.Status = status;
            s.Manager =manager;
            var c2 = new RoomModel();
            c2.Id = s.Id;
            c2.Status = s.Status;
            c2.Manager = s.Manager;
            if (ModelState.IsValid)
            {
                DB.Rooms.Add(s);
                DB.SaveChanges();
            }
            return Json(c2, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteRoom(string Id)
        {
            Room r = DB.Rooms.Find(Id);
            var roomModel = new RoomModel();
            roomModel.Id = r.Id;
            roomModel.Status = r.Status;
            roomModel.Manager = r.Manager;
            if (ModelState.IsValid)
            {
                DB.Rooms.Remove(r);
                DB.SaveChanges();
            }
            return Json(roomModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddSubject(string id, string name, int credits,int feePerCredit)
        {
            var s1 = DB.Subjects.Find(id);
            if (s1 != null) return Json(false, JsonRequestBehavior.AllowGet);

            Subject s = new Subject();
            s.Id = id;
            s.Credits = credits;
            s.Name = name;
            s.FeePerCredit = feePerCredit;

            var s2 = new SubjectModel();
            s2.Id = s.Id;
            s2.Name = s.Name;
            s2.Credits = s.Credits;
            s2.FeePerCredit = s.FeePerCredit;
            if (ModelState.IsValid)
            {
                DB.Subjects.Add(s);
                DB.SaveChanges();
            }
            return Json(s2, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteSubject(string Id)
        {
            Subject s = DB.Subjects.Find(Id);
            var subjectModel = new SubjectModel();
            subjectModel.Id = s.Id;
            subjectModel.Name = s.Name;
            subjectModel.Credits = s.Credits;
            subjectModel.FeePerCredit = s.FeePerCredit;
            if (ModelState.IsValid)
            {
                DB.Subjects.Remove(s);
                DB.SaveChanges();
            }
            return Json(subjectModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddTeacher(string id, string name, string idc, string email)
        {
            var t1 = DB.Subjects.Find(id);
            if (t1 != null) return Json(false, JsonRequestBehavior.AllowGet);

            Teacher t = new Teacher();
            t.Id = id;
            t.Idc = idc;
            t.Name = name;
            t.Email = email;

            var t2 = new TeacherModel();
            t2.Id = t.Id;
            t2.Name = t.Name;
            t2.Idc = t.Idc;
            t2.Email = t.Email;
            if (ModelState.IsValid)
            {
                DB.Teachers.Add(t);
                DB.SaveChanges();
            }
            return Json(t2, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteTeacher(string Id)
        {
            Teacher s = DB.Teachers.Find(Id);
            var teacherModel = new TeacherModel();
            teacherModel.Id = s.Id;
            teacherModel.Name = s.Name;
            teacherModel.Idc = s.Idc;
            teacherModel.Email = s.Email;
            if (ModelState.IsValid)
            {
                DB.Teachers.Remove(s);
                DB.SaveChanges();
            }
            return Json(teacherModel, JsonRequestBehavior.AllowGet);
        }



    }
}