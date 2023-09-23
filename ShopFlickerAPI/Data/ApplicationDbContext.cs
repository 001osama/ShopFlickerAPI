using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopFlickerAPI.Models;
using ShopFlickerAPI.Models.DTO;

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
                    Amount = 1.99,
                    Desc = "Fresh carrots from the local farm.",
                    ImageUrl = "none",
                    CreatedDate = DateTime.Now.AddMonths(-2)
                },
                new Product
                {
                    Id = 2,
                    Name = "Broccoli",
                    Amount = 2.49,
                    ImageUrl = "none",
                    Desc = "Organic broccoli for a healthy diet.",
                    CreatedDate = DateTime.Now.AddMonths(-1)
                },
                new Product
                {
                    Id = 3,
                    Name = "Spinach",
                    Amount = 1.79,
                    ImageUrl = "none",
                    Desc = "Leafy green spinach, perfect for salads.",
                    CreatedDate = DateTime.Now.AddMonths(-3)
                },
                new Product
                {
                    Id = 4,
                    Name = "Tomatoes",
                    Amount = 2.99,
                    ImageUrl = "none",
                    Desc = "Vine-ripened tomatoes for your recipes.",
                    CreatedDate = DateTime.Now.AddMonths(-2)
                },
                new Product
                {
                    Id = 5,
                    Name = "Cucumbers",
                    Amount = 1.49,
                    ImageUrl = "none",
                    Desc = "Crunchy cucumbers for snacking.",
                    CreatedDate = DateTime.Now.AddMonths(-2)
                }
                );   
        }
    }
}
