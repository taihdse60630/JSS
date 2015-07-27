using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSearchingSystem.Models;
using JobSearchingSystem.DAL;
namespace JobSearchingSystem.Controllers
{
    public class JobController : Controller
    {
        //
        // GET: /Job/
        private JobUnitOfWork jobUnitOfWork = new JobUnitOfWork();
        private HomeUnitOfWork homeUnitOfWork = new HomeUnitOfWork();
        public ActionResult Index()
        {
            return View();
        }

        //Displayed list of job created by recruiter
        public ActionResult OwnList()
        {
            string recruiterID = "1";
            return View(this.jobUnitOfWork.GetJobByRecruiterID(recruiterID));
        }

        [Authorize(Roles = "Jobseeker")]
        public ActionResult AppliedJobList()
        {
            string userID = jobUnitOfWork.AspNetUserRepository.Get(s => s.UserName == User.Identity.Name).FirstOrDefault().Id;
            AppliedJobViewModel model = new AppliedJobViewModel();
            model.AppliedJobList = jobUnitOfWork.getAppliedJobList(userID);
            return View(model);
        }

        public ActionResult DeleteAppliedRequest(int jobId, string jobseekerId)
        {
            int deleteResult = jobUnitOfWork.DeleteAppliedRequest(jobId, jobseekerId);
            return RedirectToAction("AppliedJobList");
        }

        public ActionResult Create()
        {
            JobCreateModel jobCreateModel = new JobCreateModel();
            jobCreateModel.JobLevelList = jobUnitOfWork.JobLevelRepository.Get(filter: d => d.IsDeleted == false);
            jobCreateModel.SchoolLevelList = jobUnitOfWork.SchoolLevelRepository.Get(filter: d => d.IsDeleted == false);
            jobCreateModel.CityList = jobUnitOfWork.CityRepository.Get(filter: city => city.IsDeleted == false);
            jobCreateModel.CategoryList = jobUnitOfWork.CategoryRepository.Get(category => category.IsDeleted == false);
            return View(jobCreateModel);
        }

        [HttpPost]
        public ActionResult Create(JobCreateModel model)
        {
            if (jobUnitOfWork.CreateJob(model))
            {
                return RedirectToAction("OwnList");
            }
            return View(model);
        }

        public ActionResult Find(JFindViewModel model)
        {
            model.jobCities = homeUnitOfWork.getAllCities();
            model.jobCategories = homeUnitOfWork.getAllCategories();
            model.schoolLevelList = homeUnitOfWork.getAllSchoolLevel();

            String searchString = model.searchString;
            if (model.searchJobCities == null && model.searchjobCategories == null)
            {
                model.searchJobCities = TempData["searchJobCities"] as IEnumerable<int>;
                model.searchjobCategories = TempData["searchJobCategories"] as IEnumerable<int>;
            }

            model.jJobItem = jobUnitOfWork.FindJob(model.searchString, model.minSalary, model.schoolLevel, model.searchJobCities, model.searchjobCategories);
            return View(model);
        }

        public ActionResult Detail(int? jobID)
        {
            int jobID2 = jobID.GetValueOrDefault();
            if (jobID2 == 0)
            {

                return RedirectToAction("Index", "Home");
            }
            else if (!jobUnitOfWork.IsJobExist(jobID2))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                JJobDetailViewModel jJobDetailViewModel = new JJobDetailViewModel();
                jJobDetailViewModel.Job = jobUnitOfWork.GetJobDetail(jobID2);

                if (!String.IsNullOrEmpty(User.Identity.Name))
                {
                    string userID = jobUnitOfWork.AspNetUserRepository.Get(s => s.UserName == User.Identity.Name).FirstOrDefault().Id;
                    IEnumerable<Profile> profileList = jobUnitOfWork.getJobSeekerProfile(userID);

                    jJobDetailViewModel.jobSeeker = jobUnitOfWork.JobseekerRepository.Get(s => s.JobSeekerID == userID).FirstOrDefault();
                    jJobDetailViewModel.profileList = profileList;

                }

                return View(jJobDetailViewModel);
            }
        }

        //Display a hidden job
        public ActionResult Display(int jobID)
        {
            if (jobUnitOfWork.Display(jobID))
            {
                return RedirectToAction("OwnList");
            }
            //ThienNN solve conflict
            return RedirectToAction("OwnList");
        }

        //    return RedirectToAction("OwnList");
        //}

        [Authorize(Roles = "Jobseeker")]
        public ActionResult AppliedJob(JJobDetailViewModel model)
        {
            string id = jobUnitOfWork.AspNetUserRepository.Get(s => s.UserName == User.Identity.Name).FirstOrDefault().Id;
            bool IsApplied = jobUnitOfWork.AppliedJob(model.jobID, model.profileID, id);
            return RedirectToAction("AppliedJobList");
        }




        //Hide a displayed job
        public ActionResult Hide(int jobID)
        {
            if (jobUnitOfWork.Hide(jobID))
            {
                return RedirectToAction("OwnList");
            }
            return RedirectToAction("OwnList");

        }
    }
}
