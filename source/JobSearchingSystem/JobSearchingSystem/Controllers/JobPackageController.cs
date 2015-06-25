using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobSearchingSystem.Controllers
{
    public class JobPackageController : Controller
    {
        //
        // GET: /JobPackage/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Choose()
        {
            return View();
        }

        public ActionResult Invoice()
        {
            return View();
        }
	}
}