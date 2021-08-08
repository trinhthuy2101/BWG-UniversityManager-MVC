using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_NET_MVC.Models;

namespace ASP_NET_MVC.Controllers.Ajax
{
    public class AjaxController : Controller
    {
        // GET: Base
        protected webt2289_StudentManager_ThuyEntities8 DB;
        public EntityState EntryState { get; private set; }

        public AjaxController()
        {
            DB = new webt2289_StudentManager_ThuyEntities8();
        }
    }
}