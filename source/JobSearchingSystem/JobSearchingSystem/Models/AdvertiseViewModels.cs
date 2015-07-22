using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSearchingSystem.Models
{
    public class AdvertiseRequestListViewModels
    {
        public IEnumerable<JPurchaseAdvertise> advertiseRequestList { get; set; }
    }
    public class JPurchaseAdvertise
    {
        public int PurchaseAdsID { get; set; }
        public int AdvertiseID { get; set; }
        public string RecruiterID { get; set; }
        public string RecruiterName { get; set; }
        public bool isVisible { get; set; }
        public bool isApproved { get; set; }
        public string AdvertiseName { get; set; }
    }
    public class AdvertiseViewModels
    {
        public IEnumerable<Advertise> advertiseList { get; set; }
        public int advertiseID { get; set; }
    }
}