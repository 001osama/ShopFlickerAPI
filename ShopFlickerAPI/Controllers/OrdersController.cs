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
        private readonly IOrderDetailRepository _dbOrderDetail;
        private readonly IOrderHeaderRepository _dbOrderHeader;
        private readonly IConfiguration _config;
        public OrdersController(
            IConfiguration config,
            IShoppingCartRepository dbCart,
            IOrderHeaderRepository dbOrderHeader,
            IOrderDetailRepository dbOrderDetail
            )
        {
            _config = config;
            _dbOrderDetail = dbOrderDetail;
            _dbOrderHeader = dbOrderHeader;
            _dbCart = dbCart;
        }

        [HttpPost]
        public async Task<ActionResult>CheckOut()
        {
            try
            {

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null)
                {
                    return Unauthorized();
                }

                IEnumerable<ShoppingCart> carts;
                carts = await _dbCart.GetAllAsync(u => u.UserId == userId, "Product");
                if (carts == null)
                {
                    return BadRequest();
                }


                var domain = _config.GetValue<string>("FrontendBaseUrl");
                var options = new SessionCreateOptions
                {
                    PaymentMethodTypes = new List<string> { "card", },
                    LineItems = new List<SessionLineItemOptions>(),
                    Mode = "payment",
                    SuccessUrl = domain + "/success",
                    CancelUrl = domain + "/unsuccess",
                };

                foreach (var item in carts)
                {
                    var sessionLineItem = new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long)(item.Product.Price * 100),
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
                session.CustomerId = userId;

                double orderTotal = 0;

                foreach (var item in carts)
                {
                    orderTotal += item.TotalPrice;
                }


                OrderHeader orderHeader = new OrderHeader()
                {
                    ApplicationUserId = userId,
                    OrderStatus = "pending",
                    PaymentStatus = "pending",
                    SessionId = session.Id,
                    OrderTotal = orderTotal,
                    
                };
                await _dbOrderHeader.CreateAsync(orderHeader);


                foreach (var cart in carts)
                {
                    OrderDetail orderDetail = new OrderDetail()
                    {
                        OrderHeaderId = orderHeader.Id,
                        ProductId = cart.ProductId,
                        Price = cart.TotalPrice,
                        Quantity = cart.Quantity
                    };
                    await _dbOrderDetail.CreateAsync(orderDetail);
                }

                Response.Headers.Add("Location", session.Url);
                return Ok(session);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
