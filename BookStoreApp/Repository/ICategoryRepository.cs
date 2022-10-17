using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        Category GetCategoryById(int id);
        void DeleteCategory(int id);
        void CreateNewCategory(Category category);
        void UpdateCategory(Category category);
    }
}
