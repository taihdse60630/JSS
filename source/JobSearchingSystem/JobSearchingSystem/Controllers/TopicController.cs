using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSearchingSystem;
using JobSearchingSystem.DAL;
using JobSearchingSystem.Models;

namespace JobSearchingSystem.Controllers
{
    public class TopicController : Controller
    {
        private TopicUnitOfWork topicUnitOfWork = new TopicUnitOfWork();
        
        // GET: /Topic/
        public ActionResult Index()
        {
            return List();
        }

        public ActionResult List()
        {
            TopListViewModel model = new TopListViewModel(topicUnitOfWork.Get());
            return View(model);
        }

        public ActionResult Create()
        {
            TopCreateViewModel model = new TopCreateViewModel();

            return View(model);
        }
        
        [HttpPost]
        public ActionResult Create(TopCreateViewModel model)
        {
            if (model != null)
            {
                Topic newTopic = new Topic();
                newTopic.WriterID = "f1be6249-eddf-4e78-9c13-9c3a0268f227";
                newTopic.Topic_content = model.Topic_content;
                newTopic.CreatedDate = DateTime.Now;
                newTopic.UpdatedDate = null;
                newTopic.UpdatedStaffID = null;
                newTopic.IsApproved = false;
                newTopic.IsDeleted = false;
                    
                bool result = this.topicUnitOfWork.Create(newTopic);

                if (result) 
                {
                    return RedirectToAction("List");
                }
                return View(model);
            }
            return View(model);
        }

        public ActionResult Detail(int id = 0)
        {
            TopicItem item = new TopicItem(topicUnitOfWork.GetByID(id));
            if (item != null)
            {
                return View(item);
            }
            else
                return List();
        }
	}
}