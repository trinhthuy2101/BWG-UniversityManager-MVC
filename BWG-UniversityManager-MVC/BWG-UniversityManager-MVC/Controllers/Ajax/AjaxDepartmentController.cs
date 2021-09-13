using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_NET_MVC.Models;
using ASP_NET_MVC.Models.AttachedModel;

namespace ASP_NET_MVC.Controllers.Ajax
{
    public class AjaxDepartmentController : BaseController
    {
        // GET: AjaxDepartment
        public ActionResult Index()
        {
            var departments = DB.Departments.ToList();
            var universities = DB.Universities.ToList();
            AttachedDepartmentModel attachedDepartment = new AttachedDepartmentModel
            {
                Departments = departments,
                Universities = universities,
            };
           
            if (checkRoleLoginModel == "Administrator")
                return View(attachedDepartment);
            else if (checkRoleLoginModel == null)
                return RedirectToAction("Login", "Account");
            else
                return RedirectToAction("NoPermission", "Base");
        }
        public JsonResult Details(string id)
        {
            Department d = DB.Departments.Find(id);
            DepartmentModel d1 = new DepartmentModel();
            d1.Id = d.Id;
            d1.Uni = d.Uni;
            d1.Name = d.Name;
            return Json(d1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(string id)
        {
            Department d = DB.Departments.Find(id);
            DB.Departments.Remove(d);
            DB.SaveChanges();
            return Json(d, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreateNew(string Id, string Uni,string Name)
        {
            var d1 = DB.Departments.Find(Id);
            if (d1 != null) return Json(false, JsonRequestBehavior.AllowGet);

            Department d = new Department();
            d.Id = Id;
            d.Uni= Uni;
            d.Name = Name;
            if (ModelState.IsValid)
            {
                DB.Departments.Add(d);
                DB.SaveChanges();
            }
            return Json(d, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(string Id, string Uni,string Name)
        {
            var d1 = DB.Departments.Find(Id);
            d1.Uni = Uni;
            d1.Name = Name;
            DB.Entry(d1).State = EntityState.Modified;
            DB.SaveChanges();
            DepartmentModel d = new DepartmentModel();
            d.Id = d1.Id;
            d.Uni = d1.Uni;
            d.Name = d1.Name;
            return Json(d, JsonRequestBehavior.AllowGet);
        }
    }
}