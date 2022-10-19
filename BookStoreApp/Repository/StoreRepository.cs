using BusinessObject.Models;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class StoreRepository : IStoreRepository
    {
        public void CreateNewStore(Store store) => StoreDAO.Instance.CreateNewStore(store);

        public Store GetStoreById(int id) => StoreDAO.Instance.GetStoreById(id);

        public List<Store> GetStores() => StoreDAO.Instance.GetStores();

        public List<Store> GetStoresNoDes() => StoreDAO.Instance.GetStoresNoDes();

        public void RemoveStore(int id) => StoreDAO.Instance.RemoveStore(id);

        public void UpdateStore(Store store) => StoreDAO.Instance.UpdateStore(store);
    }
}
