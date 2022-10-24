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
    }
}
