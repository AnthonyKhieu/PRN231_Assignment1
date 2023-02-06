using BusinessObject;
using DataAccess;
using DataAccess.DTOs;
using eStoreAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<CategoryRespond> categoryResponds()
        {
            return CategoryDAO.GetCategories();
        }

        public void CreateCategory(CategoryRespond cate)
        {
             CategoryDAO.CreateCategory(cate);
        }

        public void DeleteCategory(Category cate)
        {
            CategoryDAO.DeleteCategory(cate);
        }

        public Category GetCategoryByID(int id)
        {
            return CategoryDAO.FindCategoryById(id);
        }

        public void UpdateCategory(int id, CategoryRespond cate)
        {
            CategoryDAO.UpdateCategory(id, cate);
        }

    }
}
