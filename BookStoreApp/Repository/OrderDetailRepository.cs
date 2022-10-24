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
    }
}
