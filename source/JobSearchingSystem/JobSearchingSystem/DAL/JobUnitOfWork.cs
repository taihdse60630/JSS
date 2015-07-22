using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobSearchingSystem.Models;

namespace JobSearchingSystem.DAL
{
    public class JobUnitOfWork : UnitOfWork
    {
        public Boolean checkCity(IEnumerable<int> searchJobCities, IEnumerable<JJobCity> cityList){
            Boolean flag = false;
            if (searchJobCities == null)
            {
                return true;
            }
            else
            {
               
                foreach (var item in cityList)
                {
                    foreach (var item2 in searchJobCities)
                    {
                        if (item2 == item.CityID)
                        {
                            flag = true;
                        }
                    }
                }
            }
        
            return flag;
        }

        public Boolean checkCategories(IEnumerable<int> searchJobCategories, IEnumerable<JJobCategory> categoryList)
        {
            Boolean flag = false;
            if (searchJobCategories == null)
            {
                return true;
            }
            else
            {

                foreach (var item in categoryList)
                {
                    foreach (var item2 in searchJobCategories)
                    {
                        if (item2 == item.CategoryID)
                        {
                            flag = true;
                        }
                    }
                }
            }

            return flag;
        }
        public IEnumerable<JJobItem> FindJob(String searchString, double minSalary, int schoolLevel, IEnumerable<int> jobCities, IEnumerable<int> jobCategories)
        {
           
            var jobList = (from j in this.JobRepository.Get()
                    join c in this.CompanyInfoRepository.Get() on j.RecruiterID equals c.RecruiterID
                    join d in this.JobLevelRepository.Get() on j.JobLevel_ID equals d.JobLevel_ID                  
                    join f in this.SchoolLevelRepository.Get() on j.MinSchoolLevel_ID equals f.SchoolLevel_ID
                    where (c.IsVisible = true && (j.IsPublic = true) && (j.StartedDate <= DateTime.Now) && (j.EndedDate >= DateTime.Now))
                    select new JJobItem()
                    {
                        JobID = j.JobID,
                        RecruiterID = j.RecruiterID,
                        JobTitle = j.JobTitle,
                        LogoURL = c.LogoURL,
                        JobLevelName = d.Name,
                        MinSalary = j.MinSalary,
                        MaxSalary = j.MaxSalary,
                        PostedDate = j.StartedDate,                       
                        SchoolLevel = f.LevelNum,
                        CompanyDescription = c.Description
                    }
                   ).ToArray();
            
            for (int i = 0; i < jobList.Length; i++)
            {
                jobList[i].JobCities = (from a in this.JobCityRepository.Get()
                                        join b in this.CityRepository.Get() on a.CityID equals b.CityID
                                        where a.JobID == jobList[i].JobID
                                        select new JJobCity()
                                        {
                                            CityID = a.CityID,
                                            Name = b.Name
                                        }).ToArray();
            }

            for (int i = 0; i < jobList.Length; i++)
            {
                jobList[i].JobSkills = (from a in this.JobSkillRepository.Get()
                                        join b in this.SkillRepository.Get() on a.Skill_ID equals b.Skill_ID
                                        where a.JobID == jobList[i].JobID
                                        select new JJobSkill()
                                        {
                                            JobID = a.JobID,
                                            SkillID = b.Skill_ID,
                                            SkillTag = b.SkillTag
                                        }).ToArray();
            }

            for (int i = 0; i < jobList.Length; i++)
            {
                jobList[i].JobCategory = (from a in this.JobCategoryRepository.Get()
                                        join b in this.CategoryRepository.Get() on a.CategoryID equals b.CategoryID
                                        where a.JobID == jobList[i].JobID
                                        select new JJobCategory()
                                        {
                                            JobID = a.JobID,
                                            CategoryID = b.CategoryID,
                                            Name = b.Name
                                        }).ToArray();
            }

             if (!String.IsNullOrEmpty(searchString))
            {
                jobList = jobList.Where(s => s.JobTitle.ToUpper().Contains(searchString.ToUpper())
                                         && ((double)s.MinSalary >= minSalary) && (s.SchoolLevel <= schoolLevel) && checkCity(jobCities,s.JobCities)
                                         && checkCategories(jobCategories, s.JobCategory)
                    ).ToArray();
            }
             else
             {
                 jobList = jobList.Where(s => ((double)s.MinSalary >= minSalary) && (s.SchoolLevel <= schoolLevel) && checkCity(jobCities, s.JobCities)
                                         && checkCategories(jobCategories, s.JobCategory)).ToArray();
             }
               
            return jobList;
        }

        public JJobItem GetJobDetail(int jobID)
        {
           JJobItem job = (from j in this.JobRepository.Get()
                    join c in this.CompanyInfoRepository.Get() on j.RecruiterID equals c.RecruiterID
                    join d in this.JobLevelRepository.Get() on j.JobLevel_ID equals d.JobLevel_ID
                    join e in this.JobCategoryRepository.Get() on j.JobID equals e.JobID
                    join f in this.SchoolLevelRepository.Get() on j.MinSchoolLevel_ID equals f.SchoolLevel_ID
                    where ((j.JobID == jobID) && (c.IsVisible = true) && (j.IsPublic = true) && (j.StartedDate <= DateTime.Now) && (j.EndedDate >= DateTime.Now))
                    select new JJobItem()
                    {
                        JobID = j.JobID,
                        RecruiterID = j.RecruiterID,
                        JobTitle = j.JobTitle,
                        LogoURL = c.LogoURL,
                        JobLevelName = d.Name,
                        MinSalary = j.MinSalary,
                        MaxSalary = j.MaxSalary,
                        PostedDate = j.StartedDate,                       
                        SchoolLevel = f.LevelNum,
                        Company = j.Company,
                        Address = c.Address,
                        JobDescription = j.JobDescription
                    }).ToArray().First();

           job.JobCities = (from a in this.JobCityRepository.Get()
                                   join b in this.CityRepository.Get() on a.CityID equals b.CityID
                                   where a.JobID == job.JobID
                                   select new JJobCity()
                                   {
                                       CityID = a.CityID,
                                       Name = b.Name
                                   }).ToArray();
           job.JobSkills = (from a in this.JobSkillRepository.Get()
                                   join b in this.SkillRepository.Get() on a.Skill_ID equals b.Skill_ID
                                   where a.JobID == job.JobID
                                   select new JJobSkill()
                                   {
                                       JobID = a.JobID,
                                       SkillID = b.Skill_ID,
                                       SkillTag = b.SkillTag
                                   }).ToArray();
           job.JobCategory = (from a in this.JobCategoryRepository.Get()
                            join b in this.CategoryRepository.Get() on a.CategoryID equals b.CategoryID
                            where a.JobID == job.JobID
                            select new JJobCategory()
                            {
                                JobID = a.JobID,
                                CategoryID = b.CategoryID,
                                Name = b.Name
                            }).ToArray();
            
           return job;
        }

        public bool IsJobExist(int jobID)
        {
            Job job = JobRepository.GetByID(jobID);
            if (job != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<JAppliedJob> getAppliedJobList()
        {
            return (from a in this.AppliedJobRepository.Get()
                    join b in this.JobRepository.Get() on a.JobID equals b.JobID
                    where a.IsDeleted == false
                    select new JAppliedJob()
                    {
                        JobName = b.JobTitle,
                        CompanyName = b.Company,
                        AppliedDate = a.ApplyDate,
                        JobID = a.JobID,
                        JobSeekerID = a.JobSeekerID
                        
                    }).AsEnumerable();
        }

        public int DeleteAppliedRequest(int jobId, string jobseekerId)
        {

            AppliedJob appliedJob = AppliedJobRepository.Get(filter: m => m.JobID == jobId && m.JobSeekerID == jobseekerId).FirstOrDefault();
            appliedJob.IsDeleted = true;
            AppliedJobRepository.Update(appliedJob);
            Save();
         
            var list = (from a in this.AppliedJobRepository.Get()
                        where a.JobID == jobId && a.JobSeekerID == jobseekerId
                        select a).ToArray();
            if (list.Length > 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}