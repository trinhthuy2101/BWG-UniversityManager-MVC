using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_NET_MVC.Models;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;

namespace ASP_NET_MVC.Controllers
{
    public class StudentController : BaseController
    {
        //SHOW
        public ActionResult Index()
        {
            List<Student> students = DB.Students.ToList();
            return View(students);
        }
        public ActionResult Details(string s)
        {
            var student = DB.Students.FirstOrDefault(st => st.Id == s);
            return View(student);
        }
        //ADD STUDENT
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveStudent(Student student)
        {
            var st = DB.Students.Find(student.Id);
            if (st!=null){
                return RedirectToAction("Notification", "Student");
            }
            if (ModelState.IsValid)
            {
                DB.Students.Add(student);
                DB.SaveChanges();
            }
            return RedirectToAction("Index","Student");
        }
        public ActionResult Notification()
        {
            return View();
        }
        //REMOVE
        public ActionResult RemoveStudent(string s)
        {
            var student = DB.Students.FirstOrDefault(st => st.Id == s);
            DB.Students.Remove(student);
            DB.SaveChanges();
            return RedirectToAction("Index", "Student");
        }
        //UPDATE
        public ActionResult UpdateStudent(string s)
        {
            var student = DB.Students.FirstOrDefault(st => st.Id == s);
            return View(student);
        }
        public ActionResult SaveUpdateStudent(Student s)
        {
            var s1 = DB.Students.Find(s.Id);
            if (s.Name != null) s1.Name = s.Name;
            if (s.Idc != null) s1.Idc = s.Idc;
            if (s.Class != null) s1.Class = s.Class;
            if (s.Email != null) s1.Email = s.Email;
            DB.Entry(s1).State = EntityState.Modified;
            DB.SaveChanges();
            return RedirectToAction("Index", "Student");
        }
    }
}