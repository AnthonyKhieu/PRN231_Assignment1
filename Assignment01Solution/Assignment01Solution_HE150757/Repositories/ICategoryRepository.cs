using BusinessObject;
using DataAccess.DTOs;
using eStoreAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICategoryRepository
    {
        List<CategoryDTO> categoryResponds();

        Category GetCategoryByID(int id);

        void DeleteCategory(Category cate);

        void UpdateCategory(int id, CategoryDTO cate);

        void CreateCategory(CategoryDTO p);


    }
}
