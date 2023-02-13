using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DataSeeding
{
    public class CatergorySeeding : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { CategoryId = 1, CategoryName = "Category 1"},
                new Category { CategoryId = 2, CategoryName = "Category 2"},
                new Category { CategoryId = 3, CategoryName = "Category 3"},
                new Category { CategoryId = 4, CategoryName = "Category 4"},
                new Category { CategoryId = 5, CategoryName = "Category 5"}
           );
        }
    }
}
