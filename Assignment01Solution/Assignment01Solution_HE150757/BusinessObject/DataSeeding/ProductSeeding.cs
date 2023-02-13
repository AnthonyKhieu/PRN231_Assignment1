using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DataSeeding
{
    public class ProductSeeding : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { ProductId = 1, ProductName = "Product A", UnitPrice = 100, UnitsInStock = 100, CategoryId = 1 },
                new Product { ProductId = 2, ProductName = "Product B", UnitPrice = 100, UnitsInStock = 100, CategoryId = 2 },
                new Product { ProductId = 3, ProductName = "Product C", UnitPrice = 100, UnitsInStock = 100, CategoryId = 3 },
                new Product { ProductId = 4, ProductName = "Product D", UnitPrice = 100, UnitsInStock = 100, CategoryId = 4 },
                new Product { ProductId = 5, ProductName = "Product E", UnitPrice = 100, UnitsInStock = 100, CategoryId = 5 }

            );
        }
    }
}
