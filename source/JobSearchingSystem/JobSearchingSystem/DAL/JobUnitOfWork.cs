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

        public IEnumerable<JAppliedJob> getAppliedJobList(string userID)
        {
            return (from a in this.AppliedJobRepository.Get()
                    join b in this.JobRepository.Get() on a.JobID equals b.JobID
                    where a.IsDeleted == false && a.JobSeekerID == userID
                    select new JAppliedJob()
                    {
                        JobName = b.JobTitle,
                        CompanyName = b.Company,
                        AppliedDate = a.ApplyDate,
                        JobID = a.JobID,
                        JobSeekerID = a.JobSeekerID,
                        Status = a.Status,
                        
                    }).AsEnumerable();
        }

        public int DeleteAppliedRequest(int jobId, string jobseekerId)
        {
            var listBeforeDelete = (from a in this.AppliedJobRepository.Get()
                        where a.JobID == jobId && a.JobSeekerID == jobseekerId && a.IsDeleted == true
                        select a).ToArray();


            AppliedJob appliedJob = AppliedJobRepository.Get(filter: m => m.JobID == jobId && m.JobSeekerID == jobseekerId).FirstOrDefault();
            appliedJob.IsDeleted = true;
            AppliedJobRepository.Update(appliedJob);
            Save();
         
            var list = (from a in this.AppliedJobRepository.Get()
                        where a.JobID == jobId && a.JobSeekerID == jobseekerId
                        select a).ToArray();
            return listBeforeDelete.Length - list.Length;
        }

        public IEnumerable<Profile> getJobSeekerProfile(string userID)
        {
            return ProfileRepository.Get(s => s.JobSeekerID == userID).AsEnumerable();
        }

        public bool AppliedJob(int jobID, int profileID, string userID)
        {
            int count = AppliedJobRepository.Get().ToArray().Length;
            AppliedJob appliedJob = new AppliedJob();
            appliedJob.JobID = jobID;
            appliedJob.ProfileID = profileID;
            appliedJob.JobSeekerID = userID;
            appliedJob.ApplyDate = DateTime.Now;
            appliedJob.Status = 0;
            appliedJob.IsDeleted = false;

            //try
            //{
                AppliedJobRepository.Insert(appliedJob);
                Save();
            //}
            //catch (Exception e)
            //{
            //    return false;
            //}
       
            if (count < AppliedJobRepository.Get().ToArray().Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Change model information into Topic class
        public Job Model_Topic(JobCreateModel model)
        {
            Job temp = new Job();
            temp.RecruiterID = model.JobInfo.RecruiterID;
            temp.JobTitle = model.JobInfo.JobTitle;
            temp.Company = model.JobInfo.Company;
            temp.Address = model.JobInfo.Address;
            temp.MinSalary = model.JobInfo.MinSalary;
            temp.MaxSalary = model.JobInfo.MaxSalary;
            temp.JobDescription = model.JobInfo.JobDescription;
            temp.JobLevel_ID = model.JobInfo.JobLevel_ID;
            temp.MinSchoolLevel_ID = model.JobInfo.MinSchoolLevel_ID;
            temp.JobView = model.JobInfo.JobView;
            temp.StartedDate = DateTime.Now;
            temp.EndedDate = DateTime.Now.AddDays(30);
            temp.IsPublic = model.JobInfo.IsPublic;
            return temp;
        }

        //Create new job
        public bool CreateJob(JobCreateModel model)
        {
            try
            {
                this.JobRepository.Insert(Model_Topic(model));
                this.Save();

                Job temp = this.JobRepository.Get(job => job.RecruiterID == model.JobInfo.RecruiterID && job.JobTitle == model.JobInfo.JobTitle).Last();

                //Add city
                foreach (int index in model.CitySelectList)
                {
                    JobCity item = new JobCity();
                    item.JobID = temp.JobID;
                    item.CityID = index;
                    this.JobCityRepository.Insert(item);
                    this.Save();
                }

                //Add category
                foreach (int index in model.CategorySelectList)
                {
                    JobCategory item = new JobCategory();
                    item.JobID = temp.JobID;
                    item.CategoryID = index;
                    this.JobCategoryRepository.Insert(item);
                    this.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Get list of job by recruiterID
        public IEnumerable<JobItem> GetJobByRecruiterID(string recruiterID)
        {
            try
            {
                List<JobItem> jobList = new List<JobItem>();
                foreach (Job job in this.JobRepository.Get(job => job.RecruiterID == recruiterID))
                {
                    if ((DateTime.Now.CompareTo(job.EndedDate) > 0) && (job.IsPublic == true))
                    {
                        job.IsPublic = false;
                        this.JobRepository.Update(job);
                        this.Save();
                    }

                    jobList.Add(new JobItem(job.JobID, job.JobTitle, job.StartedDate, job.EndedDate, job.IsPublic, job.AppliedJobs.Count()));
                }
                return jobList;
            }
            catch
            {
                return null;
            }
        }

        //Display a hidden job
        public bool Display(int jobID)
        {
            try
            {
                Job temp = this.JobRepository.Get(job => job.JobID == jobID).SingleOrDefault();
                if (temp == null) return false;
                temp.IsPublic = true;

                this.JobRepository.Update(temp);
                this.Save();

                return true;
            }
            catch
            {
                return false;
            }
        }

        //Hide a displayed job
        public bool Hide(int jobID)
        {
            try
            {
                Job temp = this.JobRepository.Get(job => job.JobID == jobID).SingleOrDefault();
                if (temp == null) return false;
                temp.IsPublic = false;

                this.JobRepository.Update(temp);
                this.Save();

                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}