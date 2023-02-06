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
    public class ProductsAPI : ControllerBase
    {
        private readonly IProductRepository repository;

        public ProductsAPI(IProductRepository repository)
        {
            this.repository = repository;
        }
         
        [HttpGet]
        public IActionResult GetAll(string? search)
        {
            List<ProductRespond> products = repository.GetProducts(search); 
            return Ok(products);
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult PostProduct(ProductRespond product)
        {
            repository.SaveProduct(product);
            return Ok(new Respond<ProductRespond>()
            {
                Success = true,
                Message = "Create new product success",
                Data = product,
            });
        }

        [HttpDelete("id")]
        [Authorize]
        public IActionResult DeleteProduct(int id)
        {
            var p = repository.GetProductByID(id);
            if(p == null)
            {
                return NotFound();
            }
            repository.DeleteProduct(p);
            return Ok(new Respond<Product>()
            {
                Success = true,
                Message = $"Delete product id {id} success",
                Data = p,
            });
        }
        [HttpPut("id")]
        [Authorize]
        public IActionResult UpdateProduct(int id,ProductRespond productRespond)
        {
            var pTmp = repository.GetProductByID(id);
            if(pTmp == null)
            {
                return NotFound();
            }
            repository.UpdateProduct(id, productRespond);
            return Ok(new Respond<ProductRespond>()
            {
                Success = true,
                Message = $"Update product id {id} success!",
                Data = productRespond,
            });
        }


    }
}
