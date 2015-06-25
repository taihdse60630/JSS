using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobSearchingSystem.Controllers
{
    public class TopicController : Controller
    {
        //
        // GET: /Topic/
        public ActionResult Index()
        {
            return List();
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }
	}
}