﻿using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IStoreRepository
    {
        List<Store> GetStores();
        Store GetStoreById(int id);
        void RemoveStore(int id);
        void CreateNewStore(Store store);
        void UpdateStore(Store store);
        List<Store> GetStoresNoDes();
        List<Store> SearchStore(string query);
    }
}
