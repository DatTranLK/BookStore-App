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
            get {
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
    }
}
