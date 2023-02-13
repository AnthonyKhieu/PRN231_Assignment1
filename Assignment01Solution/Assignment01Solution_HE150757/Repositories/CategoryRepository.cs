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
        public List<CategoryDTO> categoryResponds()
        {
            return CategoryDAO.GetCategories();
        }

        public void CreateCategory(CategoryDTO cate)
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

        public void UpdateCategory(int id, CategoryDTO cate)
        {
            CategoryDAO.UpdateCategory(id, cate);
        }

    }
}
