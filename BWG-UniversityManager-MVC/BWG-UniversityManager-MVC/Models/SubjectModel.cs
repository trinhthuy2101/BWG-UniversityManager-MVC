﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_MVC.Models
{
    public class SubjectModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        
        public Nullable<int> Credits { get; set; }
        public Nullable<int> FeePerCredit { get; set; }

    }
}