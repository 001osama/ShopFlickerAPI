using Microsoft.EntityFrameworkCore;
using ShopFlickerAPI.Models;

namespace ShopFlickerAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {}

        public DbSet<Product> Products { get; set; }
    }
}
