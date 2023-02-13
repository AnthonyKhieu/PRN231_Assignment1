using BusinessObject;
using DataAccess.DTOs;
using eStoreAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDAO
    {
        public static AppDBContext context = new AppDBContext();

        public static List<CategoryDTO> GetCategories()
        {
            var categories = new List<CategoryDTO>();
            try
            {
                categories = context.Categories.Select(c => new CategoryDTO
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                }).ToList();
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return categories;
        }

        public static Category FindCategoryById(int cid)
        {
            Category cate = new Category();
            try
            {
                cate = context.Categories.SingleOrDefault(p => p.CategoryId == cid);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cate;
        }

        public static void CreateCategory(CategoryDTO categoryRespond)
        {
            try
            {
                var category = new Category
                {
                    CategoryName = categoryRespond.CategoryName,               
                };
                context.Categories.Add(category);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteCategory(Category category)
        {
            try
            {
                var cate = context.Categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);
                context.Categories.Remove(cate);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateCategory(int id, CategoryDTO categoryRespond)
        {
            try
            {
                var categoryUpdate = context.Categories.SingleOrDefault(c=> c.CategoryId == id);
                categoryUpdate.CategoryName = categoryRespond.CategoryName;
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
