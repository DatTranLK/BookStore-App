using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class RequetBookDetailDAO
    {
        private static RequetBookDetailDAO instance;
        private static readonly object instanceLock = new object();
        BookStoreDBContext _dbContext = new BookStoreDBContext();
        public RequetBookDetailDAO()
        {

        }
        public static RequetBookDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RequetBookDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public void AddNewRequestBookDetail(int quantity, int requestBookId, int bookId)
        {
            try
            {
                var requestBookDetail = new RequestBookDetail();
                requestBookDetail.RealQuantity = quantity;
                requestBookDetail.BookId = bookId;
                requestBookDetail.RequestBookId = requestBookId;
                _dbContext.RequestBookDetails.Add(requestBookDetail);
                _dbContext.SaveChanges();
                var book = _dbContext.Books.FirstOrDefault(x => x.Id == bookId);
                if (book != null)
                {
                    book.Amount += quantity;
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<RequestBookDetail> GetRequestBookDetailByRequestId(int requestBookId)
        {
            try
            {
                var detail = _dbContext.RequestBookDetails
                    .Include(x => x.Book)
                    .Where(x => x.RequestBookId == requestBookId).ToList();
                if (detail == null)
                {
                    return null;
                }
                return detail;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void DeleteRequestDetails(int requestBookId)
        {
            try
            {
                var requestDetail = GetRequestBookDetailByRequestId(requestBookId);
                if (requestDetail != null)
                {

                    foreach (var item in requestDetail)
                    {
                        _dbContext.RequestBookDetails.Remove(item);
                        _dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
