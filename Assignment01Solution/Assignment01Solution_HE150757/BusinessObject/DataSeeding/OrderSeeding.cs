using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DataSeeding
{
    public class OrderSeeding : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
                new Order
                {
                    OrderId = 1,
                    Freight = 10,
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now.AddDays(7),
                    ShippedDate = DateTime.Now.AddDays(7),
                    MemberId = 1

                },
                new Order
                {
                    OrderId = 2,
                    Freight = 10,
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now.AddDays(7),
                    ShippedDate = DateTime.Now.AddDays(7),
                    MemberId = 1

                },
                new Order
                {
                    OrderId = 3,
                    Freight = 10,
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now.AddDays(7),
                    ShippedDate = DateTime.Now.AddDays(7),
                    MemberId = 1
                },
                new Order
                {
                    OrderId = 4,
                    Freight = 10,
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now.AddDays(7),
                    ShippedDate = DateTime.Now.AddDays(7),
                    MemberId = 1
                },
                new Order
                {
                    OrderId = 5,
                    Freight = 10,
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now.AddDays(7),
                    ShippedDate = DateTime.Now.AddDays(7),
                    MemberId = 2
                },
                new Order
                {
                    OrderId = 6,
                    Freight = 10,
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now.AddDays(7),
                    ShippedDate = DateTime.Now.AddDays(7),
                    MemberId = 2
                },
                new Order
                {
                    OrderId = 7,
                    Freight = 10,
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now.AddDays(7),
                    ShippedDate = DateTime.Now.AddDays(7),
                    MemberId = 2,
                }
            );
        }
    }
}
