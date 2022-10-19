using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class BookInStoreDAO
    {
        private static BookInStoreDAO instance;
        private static readonly object instanceLock = new object();
        BookStoreDBContext _dbContext = new BookStoreDBContext();
        public BookInStoreDAO()
        {

        }
        public static BookInStoreDAO Instance
        {
            get {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookInStoreDAO();
                    }
                    return instance;
                }
            }
        }
        public List<BookInStore> GetBookInStores(int storeId)
        {
            try
            {
                var lst = _dbContext.BookInStores.Where(x => x.StoreId == storeId)
                    .Include(x => x.Store)
                    .Include(x => x.Book)
                    .OrderByDescending(x => x.Id)
                    .ToList();
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
        public BookInStore GetBookInStore(int id)
        {
            try
            {
                var bis = _dbContext.BookInStores
                    .Include(x => x.Store)
                    .Include(x => x.Book)
                    .FirstOrDefault(x => x.Id == id);
                if (bis != null)
                { 
                    return bis;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void CreateNewBookInStore(BookInStore bookInStore, Book bookById)
        {
            try
            {
                if (bookById.Amount >= bookInStore.Amount)
                {
                    bookById.Amount -= bookInStore.Amount;
                    _dbContext.SaveChanges();
                    _dbContext.BookInStores.Add(bookInStore);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void UpdateBookInStore(BookInStore bookInStore, Book bookById)
        {
            try
            {
                if (bookById.Amount >= bookInStore.Amount)
                {
                    bookById.Amount -= bookInStore.Amount;
                    _dbContext.SaveChanges();
                    _dbContext.ChangeTracker.Clear();
                    _dbContext.Entry<BookInStore>(bookInStore).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
