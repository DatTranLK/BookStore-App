using BusinessObject.Models;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        public int CreateNewOrder(Order order) => OrderDAO.Instance.CreateNewOrder(order);

        public List<Order> GetOrderByCustomerID(int id) => OrderDAO.Instance.GetOrderByCustomerID(id);

        public List<Order> GetOrderByStaffID(int id) => OrderDAO.Instance.GetOrderByStaffID(id);

        public List<Order> GetOrders() => OrderDAO.Instance.GetOrders();

        public List<Order> SearchOrder(string v) => OrderDAO.Instance.SearchOrder(v);
    }
}
