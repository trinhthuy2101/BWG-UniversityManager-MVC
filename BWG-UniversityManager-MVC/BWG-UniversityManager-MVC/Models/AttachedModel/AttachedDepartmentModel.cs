using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_MVC.Models.AttachedModel
{
    public class AttachedDepartmentModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<University> Universities { get; set; }
    }
}