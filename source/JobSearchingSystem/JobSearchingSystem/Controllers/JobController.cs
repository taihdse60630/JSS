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

        public ActionResult OwnList()
        {
            return View();
        }

        public ActionResult AppliedJobList()
        {
            AppliedJobViewModel model = new AppliedJobViewModel();
            model.AppliedJobList = jobUnitOfWork.getAppliedJobList();
            return View(model);
        }

        public ActionResult DeleteAppliedRequest(int jobId, string jobseekerId)
        {
            int deleteResult = jobUnitOfWork.DeleteAppliedRequest(jobId, jobseekerId);
            return RedirectToAction("AppliedJobList");
        }

        public ActionResult Create()
        {
            return View();
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
        
            model.jJobItem = jobUnitOfWork.FindJob(model.searchString, model.minSalary,  model.schoolLevel, model.searchJobCities, model.searchjobCategories);
            return View(model);
        }
       
        public ActionResult Detail(int? jobID)
        {
            int jobID2 = jobID.GetValueOrDefault();
            if (jobID2 == 0)
            {
                
                return RedirectToAction("Index","Home");
            }
            else if (!jobUnitOfWork.IsJobExist(jobID2))
            {
                return RedirectToAction("Index", "Home");
            }else
            {              
                JJobDetailViewModel jJobDetailViewModel = new JJobDetailViewModel();
                jJobDetailViewModel.Job = jobUnitOfWork.GetJobDetail(jobID2);
                return View(jJobDetailViewModel);           
            }

          
            
            
        }
	}
}