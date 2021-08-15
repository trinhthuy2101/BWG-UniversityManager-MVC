using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_NET_MVC.Models;

namespace ASP_NET_MVC.Controllers.Ajax
{
    public class AjaxUniversityController : BaseController
    {
        // GET: AjaxUniversity
        public ActionResult Index()
        {
            List<University > UniversityList = DB.Universities.ToList();
            if (checkRoleLoginModel == "Administrator")
                return View(UniversityList);
            else if (checkRoleLoginModel == null)
                return RedirectToAction("Login", "Account");
            else
                return RedirectToAction("NoPermission", "Base");
        }
        public JsonResult Details(string id)
        {
            University u = DB.Universities.Find(id);
            UniversityModel u1 = new UniversityModel();
            u1.Id = u.Id;
            u1.Name = u.Name;
            return Json(u1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(string id)
        {
            University u = DB.Universities.Find(id);
            DB.Universities.Remove(u);
            DB.SaveChanges();
            UniversityModel u1 = new UniversityModel();
            u1.Id = u.Id;
            u1.Name = u.Name;
            return Json(u1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreateNew(string Id, string name)
        {
            var u1 = DB.Universities.Find(Id);
            if (u1 != null) return Json(false, JsonRequestBehavior.AllowGet);

            University u = new University();
            u.Id =Id;
            u.Name = name;
            if (ModelState.IsValid)
            {
                DB.Universities.Add(u);
                DB.SaveChanges();
            }
            return Json(u, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(string Id, string name)
        {
            var u1 = DB.Universities.Find(Id);
            u1.Name = name;
            DB.Entry(u1).State = EntityState.Modified;
            DB.SaveChanges();
            UniversityModel u = new UniversityModel();
            u.Id = u1.Id;
            u.Name = u1.Name;
            return Json(u, JsonRequestBehavior.AllowGet);
        }
    }
}