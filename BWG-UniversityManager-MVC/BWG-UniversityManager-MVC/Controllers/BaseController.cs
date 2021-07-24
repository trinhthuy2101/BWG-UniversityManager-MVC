using ASP_NET_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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