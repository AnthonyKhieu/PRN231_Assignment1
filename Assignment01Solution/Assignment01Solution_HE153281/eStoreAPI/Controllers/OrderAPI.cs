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
    public class OrderAPI : ControllerBase
    {
        private readonly IOrderRepository repository;

        public OrderAPI(IOrderRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Order> orders = repository.GetOrders();
            return Ok(orders);
        }

        [HttpPost]
        public IActionResult AddOrder(OrderRespond orderRespond)
        {
            repository.SaveOrder(orderRespond);
            return Ok(new Respond<OrderRespond>()
            {
                Success = true,
                Message = "Create new product success",
                Data = orderRespond,
            });
        }

        [HttpPut("id")]
        public IActionResult UpdateOrder(int id, OrderRespond orderRespond)
        {
            var ordTmp = repository.GetOrderByID(id);
            if (ordTmp == null)
            {
                return NotFound();
            }
            repository.UpdateOrder(id, orderRespond);
            return Ok(new Respond<OrderRespond>()
            {
                Success = true,
                Message = $"Update product id {id} success!",
                Data = orderRespond,
            });
        }


    }
}
