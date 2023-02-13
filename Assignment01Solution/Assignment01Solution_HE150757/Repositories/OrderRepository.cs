using BusinessObject;
using DataAccess;
using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Order GetOrderByID(int id)
        {
           return OrderDAO.FindOrderById(id);
        }

        public List<Order> GetOrders()
        {
            return OrderDAO.GetAllOrders();
        }

        public void SaveOrder(OrderDTO ord)
        {
             OrderDAO.AddOrder(ord);
        }

        public void UpdateOrder(int id, OrderDTO ord)
        {
            OrderDAO.UpdateOrder(id, ord);
        }
    }
}
