//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobSearchingSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class City
    {
        public City()
        {
            this.CompanyInfoCities = new HashSet<CompanyInfoCity>();
            this.Contacts = new HashSet<Contact>();
            this.ExpectedCities = new HashSet<ExpectedCity>();
            this.JobCities = new HashSet<JobCity>();
        }
    
        public int CityID { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual ICollection<CompanyInfoCity> CompanyInfoCities { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<ExpectedCity> ExpectedCities { get; set; }
        public virtual ICollection<JobCity> JobCities { get; set; }
    }
}
