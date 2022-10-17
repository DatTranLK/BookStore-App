using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        Book GetBookById(int id);
        void RemoveBook(int id);
        void CreateNewBook(Book book);
        void UpdateBook(Book book);
        List<Book> GetBooksInStore();
    }
}
