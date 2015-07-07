using JobSearchingSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSearchingSystem.Models;

namespace JobSearchingSystem.Controllers
{
    public class HomeController : Controller
    {
        private HomeUnitOfWork homeUnitOfWork = new HomeUnitOfWork();

        public ActionResult Index()
        {
            HIndexViewModel hIndexViewModel = new HIndexViewModel();
            homeUnitOfWork.getAllJob(hIndexViewModel);

            return View(hIndexViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Find(HIndexViewModel model)
        {
            JFindViewModel jFindViewModel = new JFindViewModel();
            jFindViewModel.searchString = model.searchString;

            return RedirectToAction("Find", "Job", jFindViewModel);
        }
    }
}