using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_MVC.Models
{
    public class RegisteredCourseModel
    {
        public string Course { get; set; }
        public string Student { get; set; }
        public Nullable<int> Point { get; set; }
        public string Fee { get; set; }

    }
}