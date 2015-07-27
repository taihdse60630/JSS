using JobSearchingSystem.DAL;
using JobSearchingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobSearchingSystem.Controllers
{
    public class JobPackageController : Controller
    {
        private PackageUnitOfWork packageUnitOfWork = new PackageUnitOfWork();

        //
        // GET: /JobPackage/
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Recruiter")]
        public ActionResult Choose()
        {
            JobPackageViewModels model = new JobPackageViewModels();
            IEnumerable<JobPackage> jobPackageList = packageUnitOfWork.GetAllPackage();
            model.jobPackageList = jobPackageList;
            return View(model);
        }

        [Authorize(Roles = "Recruiter")]
        public ActionResult Invoice(string jobPackageID)
        {
            if (String.IsNullOrEmpty(jobPackageID))
            {
                return RedirectToAction("Choose");
            }
            else
            {
                try{
                    InvoiceVIewModels model = new InvoiceVIewModels();
                    model.jobPackage = packageUnitOfWork.GetJobPackageById(Int32.Parse(jobPackageID));
                    return View(model);
                }catch(Exception e){
                    return RedirectToAction("Choose");
                }
             
            }
            
        }

         [Authorize(Roles = "Recruiter")]
        public ActionResult SendPackageRequest(InvoiceVIewModels model)
        {
            int quantity = model.packageQuantity;
            int packageID = model.jobPackageID;
            string userID = packageUnitOfWork.AspNetUserRepository.Get(s => s.UserName == User.Identity.Name).FirstOrDefault().Id; ;
            packageUnitOfWork.CreateJobPackageRequest(userID, packageID, quantity);
            return RedirectToAction("Choose");
  
        }

        public ActionResult JobPackageRequestList()
        {
           IEnumerable<JPurchaseJobPackage> purchaseJobPackageList = packageUnitOfWork.GetAllJobPackageRequest();
           JobPackageRequestViewModels model = new JobPackageRequestViewModels();
           model.purchaseJobPackageList = purchaseJobPackageList;
           return View(model);
        }

        public ActionResult AcceptJobPackageRequest(int purchaseJobPackageID)
        {
            packageUnitOfWork.AcceptJobPackageRequest(purchaseJobPackageID);
            return RedirectToAction("JobPackageRequestList");
        }

        public ActionResult DeleteJobPackageRequest(int purchaseJobPackageID)
        {
            packageUnitOfWork.DeleteJobPackageRequest(purchaseJobPackageID);
            return RedirectToAction("JobPackageRequestList");
        }

        public ActionResult AcceptMultiJobPackage(string [] purchaseJobPackageID)
        {
            try
            {
                List<int> listAccept = new List<int>();
                foreach (var item in purchaseJobPackageID)
                {
                    listAccept.Add(Int32.Parse(item));
                }
                packageUnitOfWork.AccepMultitJobPackageRequest(listAccept);
            }
            catch (Exception e)
            {
                return RedirectToAction("JobPackageRequestList");
            }

            return RedirectToAction("JobPackageRequestList");
        }

        public ActionResult DeleteMultiJobPackage(string[] purchaseJobPackageID)
        {
            try
            {
                List<int> listDelete = new List<int>();
                foreach (var item in purchaseJobPackageID)
                {
                    listDelete.Add(Int32.Parse(item));
                }
                packageUnitOfWork.DeleteMultitJobPackageRequest(listDelete);
            }
            catch (Exception e)
            {
                return RedirectToAction("JobPackageRequestList");
            }

            return RedirectToAction("JobPackageRequestList");
        }
	}
}