using JobSearchingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSearchingSystem.DAL
{
    public class AdvertiseUnitOfrWork:UnitOfWork
    {

        public IEnumerable<Advertise> GetAllAdvertise()
        {
            return AdvertiseRepository.Get();
        }

        public void CreateAdvertiseRequest(string userID, int advertiseID)
        {
            CompanyInfo companyInfo = CompanyInfoRepository.GetByID(userID);
            PurchaseAdvertise purchaseAdvertise = new PurchaseAdvertise();
            purchaseAdvertise.AdvertiseID = advertiseID;
            purchaseAdvertise.LogoUrl = companyInfo.LogoURL;
            purchaseAdvertise.RecuiterID = userID;
            purchaseAdvertise.PurchasedDate = DateTime.Now;
            purchaseAdvertise.EndDate = DateTime.Now.AddDays(30);
            purchaseAdvertise.IsVisible = false;
            purchaseAdvertise.IsApproved = false;
            purchaseAdvertise.LinkUrl = "";

            PurchaseAdvertiseRepository.Insert(purchaseAdvertise);
            Save();
        }

        public IEnumerable<JPurchaseAdvertise> GetAllAdvertiseRequest()
        {
            return (from a in this.PurchaseAdvertiseRepository.Get()
                    join b in this.AspNetUserRepository.Get() on a.RecuiterID equals b.Id
                    join c in this.AdvertiseRepository.Get() on a.AdvertiseID equals c.AdvertiseID
                    select new JPurchaseAdvertise
                    {
                        PurchaseAdsID = a.PurchaseAdsID,
                        RecruiterID = a.RecuiterID,
                        RecruiterName = b.UserName,
                        AdvertiseID = a.AdvertiseID,
                        AdvertiseName = c.Name
                    }).AsEnumerable();
        }

        public void AccepMultiAdvertise(List<int> listAccept)
        {
            foreach (var item in listAccept)
            {
                int PurchaseAdsID = item;
                PurchaseAdvertise purchaseAdvertise = PurchaseAdvertiseRepository.GetByID(PurchaseAdsID);
                purchaseAdvertise.IsApproved = true;
                PurchaseAdvertiseRepository.Update(purchaseAdvertise);
                Save();
            }
        }
    }
}