using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class OrderDAO
    {
        private static OrderDAO instance;
        private static readonly object instanceLock = new object();
        BookStoreDBContext _dbContext = new BookStoreDBContext();
        public OrderDAO()
        {

        }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }
        public List<Order> GetOrders()
        {
            try
            {
                var orders = _dbContext.Orders
                    .Include(o => o.Customer)
                    .Include(o => o.Staff)
                    .OrderByDescending(x => x.Id)
                    .ToList();
                if (orders != null)
                {
                    return orders;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public int CreateNewOrder(Order order)
        {
            try
            {
                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();

                return order.Id;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Order> GetOrderByStaffID(int id)
        {
            try
            {
                var order = _dbContext.Orders.Where(o => o.StaffId == id)
                    .Include(x => x.Staff)
                    .ToList();
                if (order != null)
                {
                    return order;
                }
                return null;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Order> GetOrderByCustomerID(int id)
        {
            try
            {
                var order = _dbContext.Orders.Where(o => o.CustomerId == id && o.StaffId == null).ToList();
                if (order != null)
                {
                    return order;
                }
                return null;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Order> SearchOrder(string v)
        {
            try
            {
                var orders = _dbContext.Orders.Where(o => o.Customer.Name.Contains(v) 
                || o.CreateDate.ToString().Contains(v) 
                || o.TotalPrice.ToString().Contains(v)
                || o.ShippingAddress.Contains(v))
                    .Include(o => o.Customer)
                    .Include(o => o.Staff)
                    .OrderByDescending(x => x.Id)
                    .ToList();
                if (orders != null)
                {
                    return orders;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
