using BusinessObject.Models;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        public void CreateNewPublisher(Publisher publisher) => PublisherDAO.Instance.CreateNewPublisher(publisher);

        public Publisher GetPublisherById(int id) => PublisherDAO.Instance.GetPublisherById(id);

        public List<Publisher> GetPublishers() => PublisherDAO.Instance.GetPublishers();

        public void RemovePublisher(int id) => PublisherDAO.Instance.RemovePublisher(id);

        public void UpdatePublisher(Publisher publisher) => PublisherDAO.Instance.UpdatePublisher(publisher);
    }
}
