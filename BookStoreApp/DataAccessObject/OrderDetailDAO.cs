using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance;
        private static readonly object instanceLock = new object();
        BookStoreDBContext _dbContext = new BookStoreDBContext();
        public OrderDetailDAO()
        {

        }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }
        
        public void AddNewOrderDetail(int quantity, int orderId, int bookId)
        {
            try
            {
                var orderDetail = new OrderDetail();
                orderDetail.Quantity = quantity;
                orderDetail.BookId = bookId;
                orderDetail.OrderId = orderId;
                _dbContext.OrderDetails.Add(orderDetail);
                _dbContext.SaveChanges();
                var book = _dbContext.Books.FirstOrDefault(x => x.Id == bookId);
                if (book != null)
                {
                    book.Amount -= quantity;
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
