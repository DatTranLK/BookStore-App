using BusinessObject.Models;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookInStoreRepository : IBookInStoreRepository
    {
        public void CreateNewBookInStore(BookInStore bookInStore, Book bookById) => BookInStoreDAO.Instance.CreateNewBookInStore(bookInStore, bookById);

        public BookInStore GetBookInStore(int id) => BookInStoreDAO.Instance.GetBookInStore(id);

        public List<BookInStore> GetBookInStores(int storeId) => BookInStoreDAO.Instance.GetBookInStores(storeId);

        public bool ImportBookToStore(int amount, int storeId, int bookId) => BookInStoreDAO.Instance.ImportBookToStore(amount, storeId, bookId);

        public void UpdateBookInStore(BookInStore bookInStore, Book bookById) => BookInStoreDAO.Instance.UpdateBookInStore(bookInStore, bookById);
    }
}
