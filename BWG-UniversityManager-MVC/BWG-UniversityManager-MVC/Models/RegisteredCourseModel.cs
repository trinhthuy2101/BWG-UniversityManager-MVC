using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BWG_UniversityManager_MVC.Models
{
    public class RegisteredCourseModel
    {
        public string Course { get; set; }
        public string Student { get; set; }
        public Nullable<int> Point { get; set; }

    }
}