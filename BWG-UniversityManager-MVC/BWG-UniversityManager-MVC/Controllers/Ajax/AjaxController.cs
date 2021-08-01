using System.Data.Entity;
using System.Web.Mvc;
using BWG_UniversityManager_MVC.Models;

namespace BWG_UniversityManager_MVC.Controllers.Ajax
{
    public class AjaxController : Controller
    {
        // GET: Base
        protected webt2289_StudentManager_ThuyEntities DB;
        public EntityState EntryState { get; private set; }

        public AjaxController()
        {
            DB = new webt2289_StudentManager_ThuyEntities();
        }
    }
}