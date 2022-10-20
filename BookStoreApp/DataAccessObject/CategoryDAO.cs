using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;
        private static readonly object instanceLock = new object();
        BookStoreDBContext _dbContext = new BookStoreDBContext();
        public CategoryDAO()
        {

        }
        public static CategoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryDAO();
                    }
                    return instance;
                }
            }
        }
        public List<Category> GetCategories()
        {
            try
            {
                var cates = _dbContext.Categories.OrderByDescending(x => x.Id).ToList();
                if(cates != null)
                {
                    return cates;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public Category GetCategoryById(int id)
        {
            try
            {
                var cate = _dbContext.Categories.FirstOrDefault(x => x.Id == id);
                if (cate != null)
                {
                    return cate;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void DeleteCategory(int id)
        {
            try
            {
                var cate = _dbContext.Categories.FirstOrDefault(x => x.Id == id);
                if (cate != null)
                {
                    if (cate.IsActive == true)
                    {
                        cate.IsActive = false;
                        _dbContext.SaveChanges();
                    }
                    else if (cate.IsActive == false)
                    {
                        cate.IsActive = true;
                        _dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void CreateNewCategory(Category category)
        {
            try
            {
                category.IsActive = true;
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void UpdateCategory(Category category)
        {
            try
            {
                category.IsActive = true;
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry<Category>(category).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
