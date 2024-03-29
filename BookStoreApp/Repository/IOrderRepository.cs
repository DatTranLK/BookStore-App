﻿using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();
        int CreateNewOrder(Order order);
        List<Order> GetOrderByStaffID(int id);
        List<Order> GetOrderByCustomerID(int id);
        List<Order> SearchOrder(string v);
    }
}
