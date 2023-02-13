using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DataSeeding
{
    internal class OrderDetailSeeding : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasData(
                new OrderDetail { OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 100, Discount = 0.3},    
                new OrderDetail { OrderId = 1, ProductId = 2, Quantity = 10, UnitPrice = 100, Discount = 0.3},    
                new OrderDetail { OrderId = 2, ProductId = 1, Quantity = 10, UnitPrice = 100, Discount = 0.3},    
                new OrderDetail { OrderId = 2, ProductId = 2, Quantity = 10, UnitPrice = 100, Discount = 0.3},    
                new OrderDetail { OrderId = 3, ProductId = 1, Quantity = 10, UnitPrice = 100, Discount = 0.3}   
            );
        }
    }
}
