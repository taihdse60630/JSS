using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSearchingSystem.DAL;

namespace JobSearchingSystem.Controllers
{
    public class ApplicantController : Controller
    {
        private ApplicantUnitOfWork applicantUnitOfWork = new ApplicantUnitOfWork();

        // GET: /Applicant/
        public ActionResult Index()
        {
            return List();
        }

        //List all applicants for a specific job
        public ActionResult List()
        {
            int jobID = 2; //Code for job getting jobID go here
            return View(applicantUnitOfWork.GetApplicantByJobID(jobID));
        }

        //Approve Applicant
        public ActionResult Approve(string applicantID)
        {
            int jobID = 2; //Code for job getting jobID go here
            if (applicantUnitOfWork.ApproveApplicant(applicantID, jobID))
            {
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }

        //Reject applicant
        public ActionResult Disapprove(string applicantID)
        {
            int jobID = 2; //Code for job getting jobID go here
            if (applicantUnitOfWork.RejectApplicant(applicantID, jobID))
            {
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }
	}
}