using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class PublisherDAO
    {
        private static PublisherDAO instance;
        private static readonly object instanceLock = new object();
        BookStoreDBContext _dbContext = new BookStoreDBContext();
        public PublisherDAO()
        {

        }
        public static PublisherDAO Instance
        {
            get {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new PublisherDAO();
                    }
                    return instance;
                }
            }

        }
        public List<Publisher> GetPublishers()
        {
            try
            {
                var publishers = _dbContext.Publishers.OrderByDescending(x => x.Id).ToList();
                if (publishers != null)
                {
                    return publishers;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public Publisher GetPublisherById(int id)
        {
            try
            {
                var publisher = _dbContext.Publishers.FirstOrDefault(x => x.Id == id);
                if (publisher != null)
                {
                    return publisher;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void RemovePublisher(int id)
        {
            try
            {
                var publisher = _dbContext.Publishers.FirstOrDefault(x => x.Id == id);
                if (publisher != null)
                {
                    if (publisher.IsActive == true)
                    {
                        publisher.IsActive = false;
                        _dbContext.SaveChanges();
                    }
                    else if (publisher.IsActive == false)
                    {
                        publisher.IsActive = true;
                        _dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void CreateNewPublisher(Publisher publisher)
        {
            try
            {
                publisher.IsActive = true;
                _dbContext.Publishers.Add(publisher);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void UpdatePublisher(Publisher publisher)
        {
            try
            {
                publisher.IsActive = true;
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry<Publisher>(publisher).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
