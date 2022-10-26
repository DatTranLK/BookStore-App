using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            get {
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

        public void AddNewOrderDetailForSeller(int quantity, int orderId, int bookInStoreId, int bookId)
        {
            try
            {
                var orderDetail = new OrderDetail();
                orderDetail.Quantity = quantity;
                orderDetail.BookInStoreId = bookInStoreId;
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

        public List<OrderDetail> GetOrderDetailDAOs(int orderId)
        {
            try
            {
                var orderDetails = _dbContext.OrderDetails
                    .Include(x => x.BookInStore.Store)
                    .Include(x => x.BookInStore.Book)
                    .Include(x => x.Order)
                    .Where(x => x.OrderId == orderId)
                    .OrderByDescending(x => x.Id)
                    .ToList();
                if (orderDetails != null)
                {
                    return orderDetails;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public OrderDetail GetOrderDetailById(int id)
        {
            try
            {
                var orderDetail = _dbContext.OrderDetails
                    .Include(x => x.BookInStore.Store)
                    .Include(x => x.BookInStore.Book)
                    .Include(x => x.Order)
                    .FirstOrDefault(x => x.Id == id);
                if (orderDetail != null)
                {
                    return orderDetail;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void RemoveOrderDetail(int id)
        {
            try
            {
                var orderDetail = _dbContext.OrderDetails.FirstOrDefault(x => x.Id == id);
                if (orderDetail != null)
                { 
                    _dbContext.OrderDetails.Remove(orderDetail);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
