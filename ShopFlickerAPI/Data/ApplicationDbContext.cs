using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopFlickerAPI.Models;

namespace ShopFlickerAPI.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {}

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderHeader> OrderHeader { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Carrots",
                    Price = 1.99,
                    Desc = "Fresh carrots from the local farm.",
                    ImageUrl = "none",
                    CreatedDate = DateTime.Now.AddMonths(-2)
                },
                new Product
                {
                    Id = 2,
                    Name = "Broccoli",
                    Price = 2.49,
                    ImageUrl = "none",
                    Desc = "Organic broccoli for a healthy diet.",
                    CreatedDate = DateTime.Now.AddMonths(-1)
                },
                new Product
                {
                    Id = 3,
                    Name = "Spinach",
                    Price = 1.79,
                    ImageUrl = "none",
                    Desc = "Leafy green spinach, perfect for salads.",
                    CreatedDate = DateTime.Now.AddMonths(-3)
                },
                new Product
                {
                    Id = 4,
                    Name = "Tomatoes",
                    Price = 2.99,
                    ImageUrl = "none",
                    Desc = "Vine-ripened tomatoes for your recipes.",
                    CreatedDate = DateTime.Now.AddMonths(-2)
                },
                new Product
                {
                    Id = 5,
                    Name = "Cucumbers",
                    Price = 1.49,
                    ImageUrl = "none",
                    Desc = "Crunchy cucumbers for snacking.",
                    CreatedDate = DateTime.Now.AddMonths(-2)
                }
            );
            modelBuilder.Entity<ShoppingCart>().HasData(
                    new ShoppingCart
                    {
                        Id = 1,
                        ProductId = 1,
                        UserId = "49372f70-f714-417a-bfbf-2b7595975a88",
                        Count = 3,
                        TotalPrice = 10.99,
                        UpdatedDate = DateTime.UtcNow,
                        CreatedDate = DateTime.UtcNow.AddHours(-1)
                    },
                    new ShoppingCart
                    {
                        Id = 2,
                        ProductId = 2,
                        UserId = "49372f70-f714-417a-bfbf-2b7595975a88",
                        Count = 2,
                        TotalPrice = 5.99,
                        UpdatedDate = DateTime.UtcNow,
                        CreatedDate = DateTime.UtcNow.AddHours(-2)
                    },
                    new ShoppingCart
                    {
                        Id = 3,
                        ProductId = 3,
                        UserId = "49372f70-f714-417a-bfbf-2b7595975a88",
                        Count = 1,
                        TotalPrice = 8.49,
                        UpdatedDate = DateTime.UtcNow,
                        CreatedDate = DateTime.UtcNow.AddHours(-3)
                    },
                    new ShoppingCart
                    {
                        Id = 4,
                        ProductId = 4,
                        UserId = "49372f70-f714-417a-bfbf-2b7595975a88",
                        Count = 4,
                        TotalPrice = 12.99,
                        UpdatedDate = DateTime.UtcNow,
                        CreatedDate = DateTime.UtcNow.AddHours(-4)
                    },
                    new ShoppingCart
                    {
                        Id = 5,
                        ProductId = 5,
                        UserId = "49372f70-f714-417a-bfbf-2b7595975a88",
                        Count = 2,
                        TotalPrice = 7.99,
                        UpdatedDate = DateTime.UtcNow,
                        CreatedDate = DateTime.UtcNow.AddHours(-5)
                    }
            );

        }
    }
}
