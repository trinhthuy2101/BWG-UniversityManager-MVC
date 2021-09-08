using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_MVC.Models.AttachedModel
{
    public class AttachedClassModel
    {
        public IEnumerable<Class> Classes { get; set; }
        public IEnumerable<Department> Departments { get; set; }
    }
}