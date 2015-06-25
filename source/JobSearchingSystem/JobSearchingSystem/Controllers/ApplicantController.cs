using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobSearchingSystem.Controllers
{
    public class ApplicantController : Controller
    {
        //
        // GET: /Applicant/
        public ActionResult Index()
        {
            return List();
        }

        public ActionResult List()
        {
            return View();
        }
	}
}