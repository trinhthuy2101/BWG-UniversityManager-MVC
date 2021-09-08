using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_MVC.Models.AttachedModel
{
    public class AttachedStudentModel
    {
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Class> Classes { get; set; }
    }
}