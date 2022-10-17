using BusinessObject.Models;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookRepository : IBookRepository
    {
        public void CreateNewBook(Book book) => BookDAO.Instance.CreateNewBook(book);

        public Book GetBookById(int id) => BookDAO.Instance.GetBookById(id);

        public List<Book> GetBooks() => BookDAO.Instance.GetBooks();

        public List<Book> GetBooksInStore() => BookDAO.Instance.GetBooksInStore();

        public void RemoveBook(int id) => BookDAO.Instance.RemoveBook(id);

        public void UpdateBook(Book book) => BookDAO.Instance.UpdateBook(book);
    }
}
