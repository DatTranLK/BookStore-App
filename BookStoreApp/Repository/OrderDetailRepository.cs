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
        public void AddNewOrderDetail(int quantity, int orderId, int bookId) => OrderDetailDAO.Instance.AddNewOrderDetail(quantity, orderId, bookId);

        public void AddNewOrderDetailForSeller(int quantity, int orderId, int bookInStoreId, int bookId) 
            => OrderDetailDAO.Instance.AddNewOrderDetailForSeller(quantity, orderId, bookInStoreId, bookId);

        public OrderDetail GetOrderDetailById(int id) => OrderDetailDAO.Instance.GetOrderDetailById(id);
        public List<OrderDetail> GetOrderDetailDAOs(int orderId) => OrderDetailDAO.Instance.GetOrderDetailDAOs(orderId);
        public void RemoveOrderDetail(int id) => OrderDetailDAO.Instance.RemoveOrderDetail(id);
    }
}
