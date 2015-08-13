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
        [Authorize(Roles = "Recruiter")]
        public ActionResult OwnList()
        {
            ViewBag.message = TempData["message"];

            string recruiterID = jobUnitOfWork.AspNetUserRepository.Get(s => s.UserName == User.Identity.Name).FirstOrDefault().Id; 
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

        [Authorize(Roles = "Recruiter")]
        public ActionResult Create()
        {
            ViewBag.message = TempData["message"];

            JobCreateModel jobCreateModel = new JobCreateModel();
            AspNetUser user = jobUnitOfWork.AspNetUserRepository.Get(s => s.UserName == User.Identity.Name).FirstOrDefault();
            if (user != null && jobUnitOfWork.RecruiterRepository.GetByID(user.Id) != null) 
            {
                string UserID = user.Id;
                jobCreateModel.JobLevelList = jobUnitOfWork.JobLevelRepository.Get(filter: d => d.IsDeleted == false);
                jobCreateModel.SchoolLevelList = jobUnitOfWork.SchoolLevelRepository.Get(filter: d => d.IsDeleted == false);
                jobCreateModel.CityList = jobUnitOfWork.CityRepository.Get(filter: city => city.IsDeleted == false);
                jobCreateModel.CategoryList = jobUnitOfWork.CategoryRepository.Get(category => category.IsDeleted == false);
                jobCreateModel.JobPackageItemSelectItemList = jobUnitOfWork.PurchaseJobPackageRepository.Get(s => s.RecruiterID == user.Id && DateTime.Now <= s.EndDate && s.IsApproved == true && s.IsDeleted == false)
                                                                .Join(jobUnitOfWork.JobPackageRepository.Get(), pur => pur.JobPackageID, jp => jp.JobPackageID, (pur, jp) => new JobPackageSelectItem { PurchaseJobPackageID = pur.PurchaseJobPackageID, JobPackageName = jp.Name }).ToList();
                jobCreateModel.SkillList = jobUnitOfWork.SkillRepository.Get(skill => skill.IsDeleted == false);
                jobCreateModel.JobInfo.RecruiterID = UserID;
                return View(jobCreateModel);
            }

            return RedirectToAction("OwnList");
        }

        [Authorize(Roles = "Recruiter")]
        [HttpPost]
        public ActionResult Create(JobCreateModel model, int PurchaseJobPackageId)
        {
            AspNetUser user = jobUnitOfWork.AspNetUserRepository.Get(s => s.UserName == User.Identity.Name).FirstOrDefault();
            if (user != null)
            {
                Recruiter recruiter = jobUnitOfWork.RecruiterRepository.GetByID(user.Id);

                if (recruiter != null)
                {
                    bool isCanPost = jobUnitOfWork.CheckIfCanPostJob(recruiter.RecruiterID);

                    if (isCanPost)
                    {
                        if (jobUnitOfWork.CreateJob(model, PurchaseJobPackageId))
                        {
                            TempData["message"] = "Tạo công việc thành công!";
                            return RedirectToAction("OwnList");
                        }
                        TempData["message"] = "Tạo công việc thất bại!";
                        return RedirectToAction("Create");
                    }
                    TempData["message"] = "Bạn cần phải mua gói công việc trước!";
                    return RedirectToAction("Create");
                }
                TempData["message"] = "Bạn cần phải dùng tài khoản Nhà tuyển dụng!";
                return RedirectToAction("Create");
            }
            TempData["message"] = "Bạn cần phải đăng ký tài khoản Nhà tuyển dụng!";
            return RedirectToAction("Create");
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
                    jJobDetailViewModel.isLogined = true;
                    string userID = jobUnitOfWork.AspNetUserRepository.Get(s => s.UserName == User.Identity.Name).FirstOrDefault().Id;
                    IEnumerable<Profile> profileList = jobUnitOfWork.getJobSeekerProfile(userID);

                    jJobDetailViewModel.jobSeeker = jobUnitOfWork.JobseekerRepository.Get(s => s.JobSeekerID == userID).FirstOrDefault();
                    jJobDetailViewModel.profileList = profileList;

                    jJobDetailViewModel.isApplied = jobUnitOfWork.CheckIsApplied(userID, jobID2);

                }
                else
                {
                    jJobDetailViewModel.isLogined = false;
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
            bool IsApplied = jobUnitOfWork.ApplyJob(model.jobID, model.profileID, id);
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
