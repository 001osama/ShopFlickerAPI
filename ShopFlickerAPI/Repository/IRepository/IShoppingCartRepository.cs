using Microsoft.AspNetCore.Mvc;
using ShopFlickerAPI.Models;

namespace ShopFlickerAPI.Repository.IRepository
{
    public interface IShoppingCartRepository: IRepository<ShoppingCart>
    {
        Task<ShoppingCart> UpdateAsync(ShoppingCart cart);

    }
}
