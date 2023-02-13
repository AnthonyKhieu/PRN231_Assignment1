using BusinessObject;
using DataAccess.DTOs;
using eStoreAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryAPI : ControllerBase
    {

        private readonly ICategoryRepository repository;

        public CategoryAPI(ICategoryRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult GetAllCategory()
        {
            List<CategoryDTO> categoryResponds = repository.categoryResponds();
            return Ok(categoryResponds);

        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryDTO category)
        {
            repository.CreateCategory(category);
            return Ok(new BaseDTO<CategoryDTO>()
            {
                Success = true,
                Message = "Create new product success",
                Data = category,
            });       
        }

        [HttpDelete("id")]
        public IActionResult DeleteCategory(int id)
        {
            var c = repository.GetCategoryByID(id);
            if (c == null)
            {
                return NotFound();
            }
            repository.DeleteCategory(c);
            return Ok(new BaseDTO<Category>()
            {
                Success = true,
                Message = $"Delete product id {id} success",
                Data = c,
            });
        }
        [HttpPut("id")]
        public IActionResult UpdateCategory(int id, CategoryDTO categoryRespond)
        {
            var pTmp = repository.GetCategoryByID(id);
            if (pTmp == null)
            {
                return NotFound();
            }
            repository.UpdateCategory(id, categoryRespond);
            return Ok(new BaseDTO<CategoryDTO>()
            {
                Success = true,
                Message = $"Update category id {id} success!",
                Data = categoryRespond,
            });
        }
    }
}
