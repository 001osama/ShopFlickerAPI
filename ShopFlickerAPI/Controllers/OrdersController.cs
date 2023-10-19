using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ShopFlickerAPI.Models;
using ShopFlickerAPI.Repository.IRepository;
using Stripe.Checkout;
using System.Security.Claims;

namespace ShopFlickerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IShoppingCartRepository _dbCart;
        public OrdersController(IShoppingCartRepository dbCart)
        {
            _dbCart = dbCart;
        }

        [EnableCors("ShopFlicker")]
        [HttpPost]
        public async Task<ActionResult>CheckOut()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(userId == null )
            {
                return Unauthorized();
            }

            IEnumerable<ShoppingCart> carts;
            carts = await _dbCart.GetAllAsync(u=> u.UserId == userId, "Product");
            if(carts == null)
            {
                return BadRequest();
            }

            var domain = "http://localhost:4200";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                SuccessUrl = domain + "/success",
                CancelUrl = domain + "/unsuccess",
            };
            
            foreach( var item in carts)
            {
                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.Product.Price*100),
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Product.Name,
                            
                        },
                    },
                    Quantity = item.Quantity,
                };
                options.LineItems.Add(sessionLineItem);
            }

            var service = new SessionService();
            Session session = service.Create(options);
            session.CustomerEmail = User.FindFirstValue(ClaimTypes.Email);

            //Response.Headers.Add("Location", session.Url);
            return Ok(session);
        }
    }
}
