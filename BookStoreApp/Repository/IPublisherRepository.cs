using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IPublisherRepository
    {
        List<Publisher> GetPublishers();
        Publisher GetPublisherById(int id);
        void RemovePublisher(int id);
        void CreateNewPublisher(Publisher publisher);
        void UpdatePublisher(Publisher publisher);
        List<Publisher> SearchPublisher(string query);
    }
}
