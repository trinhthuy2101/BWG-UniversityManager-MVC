using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_MVC.Models
{
    public class ViewModels
    {
        public List<Course> ViewModelCourse { get; set; }
        public List<Teacher> ViewModelTeacher { get; set; }
        public List<Subject> ViewModelSubject { get; set; }
        public List<Room> ViewModelRoom { get; set; }
    }
}