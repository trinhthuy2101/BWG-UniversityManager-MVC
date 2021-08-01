using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using BWG_UniversityManager_MVC.Models;

namespace BWG_UniversityManager_MVC.Controllers.Ajax
{
    public class AjaxClassController : AjaxController
    {
        // GET: AjaxClass
        public ActionResult Index()
        {
            List<Class> classList = DB.Classes.ToList();
            return View(classList);
        }
        public JsonResult Details(string id)
        {
            Class c = DB.Classes.Find(id);
            ClassModel c1 = new ClassModel();
            c1.Id = c.Id;
            c1.Dep = c.Dep;
            return Json(c1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(string id)
        {
            Class c = DB.Classes.Find(id);
            DB.Classes.Remove(c);
            DB.SaveChanges();
            return Json(c, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreateNew(string Id, string Dep)
        {
            var c1 = DB.Classes.Find(Id);
            if (c1 != null) return Json(false, JsonRequestBehavior.AllowGet);

            Class c = new Class();
            c.Id = Id;
            c.Dep = Dep;
            if (ModelState.IsValid)
            {
                DB.Classes.Add(c);
                DB.SaveChanges();
            }
            return Json(c, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(string Id, string Dep)
        {
            var c1 = DB.Classes.Find(Id);
            c1.Dep = Dep;
            DB.Entry(c1).State = EntityState.Modified;
            DB.SaveChanges();
            ClassModel c = new ClassModel();
            c.Id = c1.Id;
            c.Dep = c1.Dep;
            return Json(c, JsonRequestBehavior.AllowGet);
        }
    }
}