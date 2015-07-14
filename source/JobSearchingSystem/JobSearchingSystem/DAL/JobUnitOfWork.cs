using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobSearchingSystem.Models;

namespace JobSearchingSystem.DAL
{
    public class JobUnitOfWork : UnitOfWork
    {
        public IEnumerable<JJobItem> FindJob(String searchString)
        {
            return (from j in this.JobRepository.Get()
                    join c in this.CompanyInfoRepository.Get()
                    on j.RecruiterID equals c.RecruiterID
                    where c.IsVisible = true
                    select new JJobItem()
                    {
                        JobID = j.JobID,
                        RecruiterID = j.RecruiterID,
                        JobTitle = j.JobTitle,
                        LogoURL = c.LogoURL
                    }
                   ).AsEnumerable();
        }

        
    }
}