using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOrderDetailRepository
    {
        void AddNewOrderDetail(int quantity, int orderId, int bookId);
        List<OrderDetail> GetOrderDetailDAOs(int orderId);
        OrderDetail GetOrderDetailById(int id);
        void RemoveOrderDetail(int id);
        void AddNewOrderDetailForSeller(int quantity, int orderId, int StoreId, int bookinstoreId);
        List<OrderDetail> GetOrderDetailDAOsVerCustomer(int orderId);
    }
}
