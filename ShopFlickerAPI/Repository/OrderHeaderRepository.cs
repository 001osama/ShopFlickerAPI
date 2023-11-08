using Microsoft.AspNetCore.Mvc;
using ShopFlickerAPI.Data;
using ShopFlickerAPI.Models;
using ShopFlickerAPI.Repository.IRepository;

namespace ShopFlickerAPI.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<OrderHeader> UpdateOrderHeader(OrderHeader entity)
        {
            _db.OrderHeader.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
