using JobSearchingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSearchingSystem.DAL
{
    public class PackageUnitOfWork:UnitOfWork
    {
        public IEnumerable<JobPackage> GetAllPackage()
        {
            return JobPackageRepository.Get();
        }

        public JobPackage GetJobPackageById(int jobPackageId)
        {
            return JobPackageRepository.GetByID(jobPackageId);
        }

        public void CreateJobPackageRequest(string userID, int packageID, int quantity)
        {
            PurchaseJobPackage purchaseJobPackage = null;
            for(int i = 0; i < quantity; i++){
            purchaseJobPackage = new PurchaseJobPackage();
            purchaseJobPackage.JobPackageID = packageID;
            purchaseJobPackage.RecruiterID = userID;
            purchaseJobPackage.PurchasedDate = DateTime.Now;
            purchaseJobPackage.IsApproved = false;
            purchaseJobPackage.EndDate = DateTime.Now.AddDays(30);

            PurchaseJobPackageRepository.Insert(purchaseJobPackage);
            Save();

            }
        

        }

        public IEnumerable<JPurchaseJobPackage> GetAllJobPackageRequest()
        {
            IEnumerable<JPurchaseJobPackage> list = (from a in this.PurchaseJobPackageRepository.Get()
                                                     join b in this.AspNetUserRepository.Get() on a.RecruiterID equals b.Id
                                                     join c in this.JobPackageRepository.Get() on a.JobPackageID equals c.JobPackageID
                                                     select new JPurchaseJobPackage
                                                     {
                                                         PurchaseJobPackageID = a.PurchaseJobPackageID,
                                                         JobPackageName = c.Name,
                                                         RecruiterName = b.UserName,
                                                         IsApproved = a.IsApproved

                                                     }).AsEnumerable();
            return list;
        }

        public void AcceptJobPackageRequest(int JobPackageID)
        {
            PurchaseJobPackage purchaseJobPackage = PurchaseJobPackageRepository.GetByID(JobPackageID);
            purchaseJobPackage.IsApproved = true;
            PurchaseJobPackageRepository.Update(purchaseJobPackage);
            Save();
        }

        public void DeleteJobPackageRequest(int purchaseJobPackageID)
        {
            //PurchaseJobPackage purchaseJobPackage = PurchaseJobPackageRepository.GetByID(JobPackageID);
       
        }

        public void AccepMultitJobPackageRequest(List<int> listAccept)
        {
            foreach (var item in listAccept)
            {
                int JobPackageID = item;
                PurchaseJobPackage purchaseJobPackage = PurchaseJobPackageRepository.GetByID(JobPackageID);
                purchaseJobPackage.IsApproved = true;
                PurchaseJobPackageRepository.Update(purchaseJobPackage);
                Save();
            }
          
        }
    }
}