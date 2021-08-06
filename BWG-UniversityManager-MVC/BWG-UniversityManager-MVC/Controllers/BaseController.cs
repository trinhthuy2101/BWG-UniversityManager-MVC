using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ASP_NET_MVC.Models;



namespace ASP_NET_MVC.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected webt2289_StudentManager_ThuyEntities8 DB;

        public EntityState EntryState { get; private set; }

        public BaseController()
        {
            DB = new webt2289_StudentManager_ThuyEntities8();
        }
    }
}