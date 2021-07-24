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
    public class ClassController : BaseController
    {
        // GET: Class
        //SHOW
        public ActionResult Index()
        {
            List<Class> classList = DB.Classes.ToList();
            return View(classList);
        }
        //ADD CLASS
        public ActionResult AddClass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveClass(Class class_model)
        {
            var cl = DB.Classes.Find(class_model.Id);
            if (cl != null)
            {
                return RedirectToAction("Notification", "Class");
            }
            if (ModelState.IsValid)
            {
                DB.Classes.Add(class_model);
                DB.SaveChanges();
            }
            return RedirectToAction("Index", "Class");
        }
        public ActionResult Notification()
        {
            return View();
        }
        //REMOVE
        public ActionResult RemoveClass(string id)
        {
            var class_model = DB.Classes.FirstOrDefault(cl => cl.Id == id);
            DB.Classes.Remove(class_model);
            DB.SaveChanges();
            return RedirectToAction("Index", "Class");
        }
        //UPDATE
        public ActionResult UpdateClass(string id)
        {
            var class_model = DB.Classes.FirstOrDefault(cl => cl.Id == id);
            return View(class_model);
        }
        public ActionResult SaveUpdateClass(Class c)
        {
            var c1 = DB.Classes.Find(c.Id);
            if(c.Dep!=null) c1.Dep = c.Dep;
            DB.Entry(c1).State = EntityState.Modified;
            DB.SaveChanges();
            return RedirectToAction("Index", "Class");
        }
    }
}