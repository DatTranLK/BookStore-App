using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBookInStoreRepository
    {
        List<BookInStore> GetBookInStores(int storeId);
        BookInStore GetBookInStore(int id);
        void CreateNewBookInStore(BookInStore bookInStore, Book bookById);
        void UpdateBookInStore(BookInStore bookInStore, Book bookById);
    }
}
