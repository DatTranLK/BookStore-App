using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
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
                var books = _dbContext.Books
                    .Include(x => x.Category)
                    .Include(x => x.Publisher)
                    .OrderByDescending(x => x.Id)
                    .ToList();
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
        public Book GetBookById(int id)
        {
            try
            {
                var book = _dbContext.Books
                    .Include(x => x.Category)
                    .Include(x => x.Publisher)
                    .FirstOrDefault(x => x.Id == id);
                if (book != null)
                {
                    return book;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void RemoveBook(int id)
        {
            try
            {
                var book = _dbContext.Books.FirstOrDefault(x => x.Id == id);
                if (book != null)
                {
                    if (book.IsActive == true)
                    {
                        book.IsActive = false;
                        _dbContext.SaveChanges();
                    }
                    else if (book.IsActive == false)
                    {
                        book.IsActive = true;
                        _dbContext.SaveChanges();
                    }
                    
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void CreateNewBook(Book book)
        {
            try
            {
                book.IsActive = true;
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void UpdateBook(Book book)
        {
            try
            {
                book.IsActive = true;
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry<Book>(book).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Book> GetBooksInStore()
        {
            var list = _dbContext.Books.Where(x => x.Amount > 0).ToList();
            if (list != null)
            {
                return list;
            }
            return null;
        }

        public List<Book> SearchBook(string searchString)
        {
            try
            {
                var books = _dbContext.Books.Where(o => o.Name.Contains(searchString)
                || o.Isbn.Contains(searchString) 
                || o.Price.ToString().Contains(searchString) 
                || o.Author.Contains(searchString))
                    .Include(x => x.Category)
                    .Include(x => x.Publisher)
                    .OrderByDescending(x => x.Id)
                    .ToList();
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
