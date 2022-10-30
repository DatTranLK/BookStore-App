using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class StoreDAO
    {
        private static StoreDAO instance;
        private static readonly object instanceLock = new object();
        BookStoreDBContext _dbContext = new BookStoreDBContext();
        public StoreDAO()
        {
                
        }
        public static StoreDAO Instance
        {
            get {
                lock (instanceLock)
                {
                    if (instance == null)
                    { 
                        instance = new StoreDAO();
                    }
                    return instance;
                }
            }
        }
        public List<Store> GetStores()
        {
            try
            {
                var lst = _dbContext.Stores.OrderByDescending(x => x.Id).ToList();
                if (lst != null)
                {
                    return lst;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public List<Store> GetStoresNoDes()
        {
            try
            {
                var lst = _dbContext.Stores.OrderBy(x => x.Id).ToList();
                if (lst != null)
                {
                    return lst;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public Store GetStoreById(int id)
        {
            try
            {
                var store = _dbContext.Stores.FirstOrDefault(x => x.Id == id);
                if (store != null)
                {
                    return store;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void RemoveStore(int id)
        {
            try
            {
                var store = _dbContext.Stores.FirstOrDefault(x => x.Id == id);
                if (store != null)
                {
                    if (store.IsActive == true)
                    {
                        store.IsActive = false;
                        _dbContext.SaveChanges();
                    }
                    else if (store.IsActive == false)
                    {
                        store.IsActive = true;
                        _dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void CreateNewStore(Store store)
        {
            try
            {
                store.IsActive = true;
                _dbContext.Stores.Add(store);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateStore(Store store)
        {
            try
            {
                store.IsActive = true;
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry<Store>(store).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Store> SearchStore(string query)
        {
            try
            {
                var lst = _dbContext.Stores.Where(o => o.Name.Contains(query) 
                || o.Address.Contains(query))
                    .OrderByDescending(x => x.Id).ToList();
                if (lst != null)
                {
                    return lst;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
