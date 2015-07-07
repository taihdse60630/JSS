using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSearchingSystem.Models
{
    public class JJobItem 
    {
        public int JobID { get; set; }
        public string RecruiterID { get; set; }
        public string JobTitle { get; set; }
        public string LogoURL { get; set; }
    }
    public class JFindViewModel
    {
        public String searchString { get; set; }
        public IEnumerable<JJobItem> jJobItem { get; set; }
    }
}