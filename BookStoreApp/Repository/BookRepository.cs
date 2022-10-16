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
        public Book GetBookById(int id) => BookDAO.Instance.GetBookById(id);

        public List<Book> GetBooks() => BookDAO.Instance.GetBooks();
    }
}
