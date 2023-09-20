using ShopFlickerAPI.Models;

namespace ShopFlickerAPI.Repository.IRepository
{
    public interface IProductRepository: IRepository<Product>
    {
        Task<Product> UpdateAsync(Product entity);
    }
}
