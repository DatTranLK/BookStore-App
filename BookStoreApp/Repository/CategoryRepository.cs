using BusinessObject.Models;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public void CreateNewCategory(Category category) => CategoryDAO.Instance.CreateNewCategory(category);

        public void DeleteCategory(int id) => CategoryDAO.Instance.DeleteCategory(id);

        public List<Category> GetCategories() => CategoryDAO.Instance.GetCategories();

        public Category GetCategoryById(int id) => CategoryDAO.Instance.GetCategoryById(id);

        public List<Category> SearchCate(string v) => CategoryDAO.Instance.SearchCategory(v);

        public void UpdateCategory(Category category) => CategoryDAO.Instance.UpdateCategory(category);
    }
}
