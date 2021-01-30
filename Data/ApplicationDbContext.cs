using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            modelBuilder.Entity<ProductType>().HasData(
                new ProductType[]
                {
                    new ProductType {Id = 1, Name = "Техника"},
                    new ProductType {Id = 2, Name = "Одежда"},
                    new ProductType {Id = 3, Name = "Обувь"},
                    new ProductType {Id = 4, Name = "Литература"},
                    new ProductType {Id = 5, Name = "Канцелярия"},
                    new ProductType {Id = 6, Name = "Прочее"},
                });
            modelBuilder.Entity<Picture>().HasData(
                new Picture[]
                {
                    new Picture {
                        Id = 1,
                        Image = File.ReadAllBytes("wwwroot/images/note9_pro_2-1000x1000.jpg") 
                    },
                    new Picture 
                    {
                        Id = 2,
                        Image = File.ReadAllBytes("wwwroot/images/kisspng-adidas-stan-smith-adidas-superstar-sneakers-shoe-asics-logo-white-5b557f05a73706.8726018415323297336849.jpg") 
                    },
                    new Picture 
                    {
                        Id = 3,
                        Image = File.ReadAllBytes("wwwroot/images/9785040925193 - .jpg") 
                    }
                });
            modelBuilder.Entity<Product>().HasData(
                new Product[]
                {
                    new Product 
                    {
                        Id = 1, 
                        Name = "Xiaomi Redmi Note 9 Pro", 
                        Price = 499, 
                        ProductTypeId = 1,
                        PictureId = 1
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Adidas Superstar",
                        Price = 150,
                        ProductTypeId = 3,
                        PictureId = 2
                    },
                    new Product
                    {
                        Id = 3, 
                        Name = "Программирование на C# для начинающих А. Н. Васильев",
                        Price = 39,
                        ProductTypeId = 4,
                        PictureId = 3
                    }
                });


        }

    }
}
