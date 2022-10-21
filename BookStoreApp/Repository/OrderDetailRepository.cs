using BusinessObject.Models;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public OrderDetail GetOrderDetailById(int id) => OrderDetailDAO.Instance.GetOrderDetailById(id);
        public List<OrderDetail> GetOrderDetailDAOs(int orderId) => OrderDetailDAO.Instance.GetOrderDetailDAOs(orderId);

        public void RemoveOrderDetail(int id) => OrderDetailDAO.Instance.RemoveOrderDetail(id);
    }
}
