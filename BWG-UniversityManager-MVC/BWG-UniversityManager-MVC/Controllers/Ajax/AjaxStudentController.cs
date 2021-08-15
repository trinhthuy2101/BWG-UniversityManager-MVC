using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_NET_MVC.Models;

namespace ASP_NET_MVC.Controllers.Ajax
{
    public class AjaxStudentController : BaseController
    {
        // GET: Student
        public ActionResult Index()
        {
            List<Student> students = DB.Students.ToList();
            if (checkRoleLoginModel == "Administrator")
                return View(students);
            else if (checkRoleLoginModel == null)
                return RedirectToAction("Login", "Account");
            else
                return RedirectToAction("NoPermission", "AjaxStudent");
        }
        public ActionResult NoPermission()
        {
            return View();
        }
        public JsonResult Details(string id)
        {
            Student s = DB.Students.Find(id);
            StudentModel s1 = new StudentModel();
            s1.Id = s.Id;
            s1.Name = s.Name;
            s1.Idc = s.Idc;
            s1.Email = s.Email;
            s1.Class = s.Class;
            return Json(s1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(string id)
        {
            Student s = DB.Students.Find(id);
            DB.Students.Remove(s);
            DB.SaveChanges();
            return Json(s, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreateNew(string Id, string Name,string Idc, string Email, string Class)
        {
            var s1 = DB.Students.Find(Id);
            if (s1!=null) return Json(false,JsonRequestBehavior.AllowGet);
            
            Student s = new Student();
            s.Id = Id;
            s.Idc = Idc;
            s.Name = Name;
            s.Email = Email;
            s.Class = Class;
            if (ModelState.IsValid)
            {
                //Create new account for student
                List<Account> accounts = DB.Accounts.ToList();
                int countAll = 0;
                accounts.ForEach(a => countAll++);
                Account account = new Account();
                account.UserName = s.Id;
                account.Password = "13579";
                account.Id = (countAll+1).ToString();

                DB.Accounts.Add(account);
                DB.Students.Add(s);
                DB.SaveChanges();
            }
            return Json(s,JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(string Id, string Name,string Idc, string Email, string Class)
        {
            var s1 = DB.Students.Find(Id);
            s1.Name = Name;
            s1.Idc = Idc;
            s1.Email = Email;
            s1.Class = Class;
            DB.Entry(s1).State = EntityState.Modified;
            DB.SaveChanges();
            StudentModel s = new StudentModel();
            s.Id = s1.Id;
            s.Name = s1.Name;
            s.Idc = s1.Idc;
            s.Email = s1.Email;
            s.Class = s1.Class;
            return Json(s,JsonRequestBehavior.AllowGet);
        }
    }
}