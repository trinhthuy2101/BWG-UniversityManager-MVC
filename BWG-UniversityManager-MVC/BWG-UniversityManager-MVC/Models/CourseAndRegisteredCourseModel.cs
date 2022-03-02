using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_MVC.Models
{
    public class CourseAndRegisteredCourse
    {
        public string Id { get; set; }
        public string Subject { get; set; }
        public string Teacher { get; set; }
        public string Room { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public string Date {get;set;}




        public string Course { get; set; }
        public string Student { get; set; }
        public Nullable<int> Point { get; set; }
        public string Fee { get; set; }


    }
}