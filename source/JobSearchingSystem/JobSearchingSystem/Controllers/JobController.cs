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
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Find(JFindViewModel model)
        {
            String searchString = model.searchString;
            model.jJobItem = jobUnitOfWork.FindJob(model.searchString);


            return View(model);
        }

        public ActionResult Detail()
        {
            return View();
        }
	}
}