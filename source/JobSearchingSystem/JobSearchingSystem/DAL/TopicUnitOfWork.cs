using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSearchingSystem.DAL
{
    public class TopicUnitOfWork : UnitOfWork
    {
        public bool Create (Topic newTopic)
        {
            if (newTopic != null)
            {
                this.TopicRepository.Insert(newTopic);
                this.Save();
                return true;
            }
            return false;
        }

        public IEnumerable<Topic> Get()
        {
            return this.TopicRepository.Get();
        }

        public Topic GetByID(int id)
        {
            return this.TopicRepository.GetByID(id);
        }
        
    }
}