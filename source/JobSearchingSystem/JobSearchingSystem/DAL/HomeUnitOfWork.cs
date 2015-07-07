using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobSearchingSystem.Models;

namespace JobSearchingSystem.DAL
{
    public class HomeUnitOfWork : UnitOfWork
    {
        public void getAllJob (HIndexViewModel model)
        {
            model.jobList = JobRepository.Get();
        }
        public void findJob(HIndexViewModel model)
        {
            var jobList = JobRepository.Get();
            if (!String.IsNullOrEmpty(model.searchString))
            {
                jobList = jobList.Where(s => s.JobTitle.ToUpper().Contains(model.searchString.ToUpper()));
            }
            model.jobList = jobList;
          
        }
        
    }
}