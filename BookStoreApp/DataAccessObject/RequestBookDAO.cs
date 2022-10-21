using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class RequestBookDAO
    {
        private static RequestBookDAO instance;
        private static readonly object instanceLock = new object();
        BookStoreDBContext _dbContext = new BookStoreDBContext();
        public RequestBookDAO()
        {

        }
        public static RequestBookDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RequestBookDAO();
                    }
                    return instance;
                }
            }
        }
        public int AddNewImportBook(RequestBook request)
        {
            try
            {
                request.AddBookState = "Done";
                request.AcceptedImport = true;
                request.Quantity = null;
                _dbContext.RequestBooks.Add(request);
                _dbContext.SaveChanges();
                return request.Id;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<RequestBook> GetRequestBooks()
        {
            try
            {
                List<RequestBook> requestBooks;
                requestBooks = _dbContext.RequestBooks.OrderByDescending(x => x.Quantity).ToList();
                return requestBooks;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteImportById(int id)
        {
            try
            {               
                var import = _dbContext.RequestBooks.FirstOrDefault(i => i.Id == id);
                if (import != null)
                {
                    _dbContext.RequestBooks.Remove(import);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public RequestBook GetRequestById(int id)
        {
            try
            {
                var request = _dbContext.RequestBooks.FirstOrDefault(i => i.Id == id);
                if (request != null)
                {
                    return request;
                }
                return null;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateImport(RequestBook requestBook)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry<RequestBook>(requestBook).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
