using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSearchingSystem.Models
{
    public class HIndexViewModel
    {
        public IEnumerable<Job> jobList { get; set; }
        public String searchString { get; set; }
    }
}