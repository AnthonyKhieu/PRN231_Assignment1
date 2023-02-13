using BusinessObject.DataSeeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {

        }
        public AppDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=PRN231_Ass1;Trusted_Connection=True;Encrypt=False;User Id=sa;Password=12345");

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Member> Members { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<User> Users { get; set; }  


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.ToTable("OrderDetail");

                e.HasKey(e => new { e.OrderId, e.ProductId });

                e.Property(e => e.UnitPrice).HasColumnType("money");

                e.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
               .HasForeignKey(d => d.OrderId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_OrderDetail_Order");

                e.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Product");

            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.Property(e => e.UnitPrice).HasColumnType("money");

            });

   

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserName).IsUnique();
                entity.Property(e => e.FullName).HasMaxLength(150);
                entity.Property(e => e.Email).HasMaxLength(150);
            });


            modelBuilder.ApplyConfiguration(new CatergorySeeding());
            modelBuilder.ApplyConfiguration(new ProductSeeding());
            modelBuilder.ApplyConfiguration(new MemberSeeding());
            modelBuilder.ApplyConfiguration(new OrderSeeding());
            modelBuilder.ApplyConfiguration(new OrderDetailSeeding());
        }
    }
}
