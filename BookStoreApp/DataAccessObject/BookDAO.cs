using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class BookDAO
    {
        private static BookDAO instance;
        private static readonly object instanceLock = new object();
        BookStoreDBContext _dbContext = new BookStoreDBContext(); 
        public BookDAO()
        {

        }
        public static BookDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    { 
                        instance = new BookDAO();
                    }
                    return instance;
                }
            }
        }
        public List<Book> GetBooks()
        {
            try
            {
                var books = _dbContext.Books.ToList();
                if (books != null)
                {
                    return books;
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
