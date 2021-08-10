using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_MVC.Models
{
    public class StudentWithPointAndCourse
    {
        public string Course { get; set; }
        public string Id { get; set; }
        public Nullable<int> Point { get; set; }
        public string Student { get; set; }

    }
}