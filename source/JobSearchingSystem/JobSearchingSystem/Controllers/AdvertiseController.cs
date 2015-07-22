using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSearchingSystem.DAL;
using JobSearchingSystem.Models;
namespace JobSearchingSystem.Controllers
{
    public class AdvertiseController : Controller
    {
        private AdvertiseUnitOfrWork advertiseUnitOfWork = new AdvertiseUnitOfrWork();
        //
        // GET: /Advertise/
         [Authorize(Roles = "Recruiter")]
        public ActionResult Index()
        {
            AdvertiseViewModels model = new AdvertiseViewModels();
            model.advertiseList = advertiseUnitOfWork.GetAllAdvertise();
            return View(model);
        }

         [Authorize(Roles = "Recruiter")]
        public ActionResult SendAdvertiseRequest(AdvertiseViewModels model)
        {
         
            int advertiseID = model.advertiseID;
            string userID = advertiseUnitOfWork.AspNetUserRepository.Get(s => s.UserName == User.Identity.Name).FirstOrDefault().Id; 
            advertiseUnitOfWork.CreateAdvertiseRequest(userID, advertiseID);
            return RedirectToAction("Index");

        }

        public ActionResult AdvertiseRequestList()
        {
            IEnumerable<JPurchaseAdvertise> purchaseAdvertise = advertiseUnitOfWork.GetAllAdvertiseRequest();
            AdvertiseRequestListViewModels model = new AdvertiseRequestListViewModels();
            model.advertiseRequestList = purchaseAdvertise;
            return View(model);
        }

        public ActionResult AcceptMultiAdvertise(string[] PurchaseAdsID)
        {
            try
            {
                List<int> listAccept = new List<int>();
                foreach (var item in PurchaseAdsID)
                {
                    listAccept.Add(Int32.Parse(item));
                }
                advertiseUnitOfWork.AccepMultiAdvertise(listAccept);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

	}
}