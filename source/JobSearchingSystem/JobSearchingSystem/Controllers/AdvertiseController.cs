using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSearchingSystem.DAL;
using JobSearchingSystem.Models;
using System.IO;
namespace JobSearchingSystem.Controllers
{
    public class AdvertiseController : Controller
    {
        private AdvertiseUnitOfrWork advertiseUnitOfWork = new AdvertiseUnitOfrWork();


        /// <summary>
        /// Creates the folder if needed.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        private bool CreateFolderIfNeeded(string path)
        {
            bool result = true;
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {
                    /*TODO: You must process this exception.*/
                    result = false;
                }
            }
            return result;
        }

        public ActionResult UploadFile(HttpPostedFileBase fileInput, string supplierId)
        {
            HttpPostedFileBase myFile = Request.Files["MyFile"];
            //var supplier = aspNetUserService.GetAspNetUserById(supplierId);

            string message = "File upload failed";
            string imageUrl = "";
            ImageModel imageModel = null;
            if (fileInput != null && fileInput.ContentLength != 0)
            {
                string pathForSaving = Server.MapPath("~/img/ImgUpload");
                imageUrl = "/img/ImgUpload/" + fileInput.FileName;
                //supplier.Image = imageUrl;
                //aspNetUserService.EditAspNetUser(supplier);
                imageModel = new ImageModel(imageUrl);
                if (this.CreateFolderIfNeeded(pathForSaving))
                {
                    try
                    {
                        fileInput.SaveAs(Path.Combine(pathForSaving, fileInput.FileName));

                        message = "File uploaded successfully!";

                    }
                    catch (Exception ex)
                    {
                        message = string.Format("File upload failed: {0}", ex.Message);
                    }
                }
            }
            //return Json(new { isUploaded = isUploaded, message = message }, "text/html");
            return PartialView("LogoPartialView", imageModel);
        }


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
         public ActionResult SendAdvertiseRequest(AdvertiseInvoiceViewModels model)
        {
         
            int advertiseID = model.advertiseID;
            string userID = advertiseUnitOfWork.AspNetUserRepository.Get(s => s.UserName == User.Identity.Name).FirstOrDefault().Id;
            string imageUrl = model.logo;
            advertiseUnitOfWork.CreateAdvertiseRequest(userID, advertiseID, imageUrl);
            return RedirectToAction("Index");

        }

        [Authorize(Roles="Staff,Admin,Manager")]
        public ActionResult AdvertiseRequestList()
        {
            IEnumerable<JPurchaseAdvertise> purchaseAdvertise = advertiseUnitOfWork.GetAllAdvertiseRequest();
            AdvertiseRequestListViewModels model = new AdvertiseRequestListViewModels();
            model.advertiseRequestList = purchaseAdvertise;
            return View(model);
        }

        [Authorize(Roles = "Staff,Admin,Manager")]
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
                return RedirectToAction("AdvertiseRequestList");
            }

            return RedirectToAction("AdvertiseRequestList");
        }

        [Authorize(Roles = "Staff,Admin,Manager")]
        public ActionResult DeleteMultiAdvertise(string[] PurchaseAdsID)
        {
            try
            {
                List<int> listAccept = new List<int>();
                foreach (var item in PurchaseAdsID)
                {
                    listAccept.Add(Int32.Parse(item));
                }
                advertiseUnitOfWork.DeleteMultiAdvertise(listAccept);
            }
            catch (Exception e)
            {
                return RedirectToAction("AdvertiseRequestList");
            }

            return RedirectToAction("AdvertiseRequestList");
        }

        [Authorize(Roles = "Recruiter")]
        public ActionResult Invoice(string advertiseID)
        {
            if (String.IsNullOrEmpty(advertiseID))
            {
                return RedirectToAction("Index");
            }
            else
            {
                try
                {
                    AdvertiseInvoiceViewModels model = new AdvertiseInvoiceViewModels();
                    model.purchaseAdvertise = advertiseUnitOfWork.GetJobAdvertiseById(Int32.Parse(advertiseID));
                    if (model.purchaseAdvertise == null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(model);
                    }
                    
                }
                catch (Exception e)
                {
                    return RedirectToAction("Index");
                }

            }

        }
	}
}