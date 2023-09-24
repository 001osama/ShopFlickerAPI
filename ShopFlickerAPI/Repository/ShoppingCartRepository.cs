using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopFlickerAPI.Data;
using ShopFlickerAPI.Models;
using ShopFlickerAPI.Repository.IRepository;
using System.Security.Claims;

namespace ShopFlickerAPI.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _db;
        public ShoppingCartRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public async Task<ShoppingCart> UpdateAsync(ShoppingCart cart)
        {
            _db.ShoppingCarts.Update(cart);
            await _db.SaveChangesAsync();
            return cart;
        }
    }
}
