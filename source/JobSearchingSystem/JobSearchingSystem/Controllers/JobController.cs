using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobSearchingSystem.Controllers
{
    public class JobController : Controller
    {
        //
        // GET: /Job/
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

        public ActionResult Find()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }
	}
}