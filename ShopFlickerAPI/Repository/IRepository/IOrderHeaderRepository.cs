using Microsoft.AspNetCore.Mvc;
using ShopFlickerAPI.Models;

namespace ShopFlickerAPI.Repository.IRepository
{
    public interface IOrderHeaderRepository: IRepository<OrderHeader>
    {
        Task<OrderHeader> UpdateOrderHeader(OrderHeader entity);

    }
}
