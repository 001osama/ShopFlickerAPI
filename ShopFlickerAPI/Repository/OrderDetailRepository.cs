using Microsoft.AspNetCore.Mvc;
using ShopFlickerAPI.Data;
using ShopFlickerAPI.Models;
using ShopFlickerAPI.Repository.IRepository;

namespace ShopFlickerAPI.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderDetailRepository(ApplicationDbContext db)
            : base(db) 
        { 
            _db = db;
        }
        public async Task<OrderDetail> UpdateOrderDetails(OrderDetail entity)
        {
            _db.OrderDetails.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
