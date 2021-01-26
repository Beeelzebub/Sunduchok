using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Сундучок.Models;

namespace Сундучок.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus[]
                {
                    new OrderStatus { Id = 1, Name = "оплачен"},
                    new OrderStatus { Id = 2, Name = "отправлен"},
                    new OrderStatus { Id = 3, Name = "прибыл"}
                });
            _ = modelBuilder.Entity<ProductType>().HasData(
                new ProductType[]
                {
                    new ProductType {Id = 1, Name = ""},
                    new ProductType {Id = 2, Name = ""},
                    new ProductType {Id = 3, Name = ""},
                    new ProductType {Id = 4, Name = ""},
                    new ProductType {Id = 5, Name = ""},
                    new ProductType {Id = 6, Name = ""},
                });


        }

    }
}
