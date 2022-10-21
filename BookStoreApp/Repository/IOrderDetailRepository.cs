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
        List<OrderDetail> GetOrderDetailDAOs(int orderId);
        OrderDetail GetOrderDetailById(int id);
        void RemoveOrderDetail(int id);
    }
}
