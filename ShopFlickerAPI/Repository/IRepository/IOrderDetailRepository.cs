using Microsoft.AspNetCore.Mvc;
using ShopFlickerAPI.Models;

namespace ShopFlickerAPI.Repository.IRepository
{
    public interface IOrderDetailRepository:IRepository<OrderDetail>
    {
        Task<OrderDetail> UpdateOrderDetails(OrderDetail entity);
    }
}
