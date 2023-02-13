using BusinessObject;
using DataAccess.DTOs;
using eStoreAPI.DTOs;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        public static AppDBContext _context = new AppDBContext();

        public OrderDAO()
        {

        }

        public static List<Order> GetAllOrders()
        {
            var orders = new List<Order>();
            try
            {
                orders = _context.Orders.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orders;
        }

        public static Order FindOrderById(int id)
        {
            Order ord = new Order();
            try
            {
                ord = _context.Orders.SingleOrDefault(p => p.OrderId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ord;
        }

        public static void AddOrder(OrderDTO orderRespond)
        {
            try
            {
                var order = new Order
                {
                    MemberId = orderRespond.MemberId,
                    OrderDate = orderRespond.OrderDate,
                    RequiredDate = orderRespond.RequiredDate,
                    ShippedDate = orderRespond.ShippedDate,
                    Freight = orderRespond.Freight,
                };
                _context.Orders.Add(order);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateOrder(int id, OrderDTO orderRespond)
        {
            try
            {
                var orderUpdate = _context.Orders.SingleOrDefault(p => p.OrderId == id);
                orderUpdate.MemberId = orderRespond.MemberId;
                orderUpdate.OrderDate = orderRespond.OrderDate;
                orderUpdate.RequiredDate = orderRespond.RequiredDate;
                orderUpdate.ShippedDate = orderRespond.ShippedDate;
                orderUpdate.Freight = orderRespond.Freight;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }

}
