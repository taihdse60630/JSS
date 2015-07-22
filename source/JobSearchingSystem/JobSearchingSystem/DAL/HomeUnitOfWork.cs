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


            


            model.jobList = jobList;
        }
     

        public IEnumerable<City> getAllCities()
        {
            return CityRepository.Get();
        }

        public IEnumerable<Category> getAllCategories()
        {
            return CategoryRepository.Get();
        }

        public IEnumerable<SchoolLevel> getAllSchoolLevel()
        {
            return SchoolLevelRepository.Get();
        }
    }
}