using Microsoft.AspNetCore.Mvc;
using ShopFlickerAPI.Models;
using ShopFlickerAPI.Repository.IRepository;
using Stripe;
using Stripe.Checkout;

namespace ShopFlickerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        private readonly ILogger<WebhookController> _logger;
        private IOrderHeaderRepository _dbOrderHeader;
        private readonly IShoppingCartRepository _dbCart;
        public WebhookController
            (
                ILogger<WebhookController> logger,
                IShoppingCartRepository dbCart,
                IOrderHeaderRepository dbOrderHeader
            )
        {
            _logger = logger;
            _dbOrderHeader = dbOrderHeader;
            _dbCart = dbCart;
        }

        const string secret = "whsec_aef2aa56603461b394d2a6b059740b53256a6dd03d2c22074db2197168cb81cf";

        [HttpPost]
        public async Task<ActionResult> Post()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            try
            {

                var stripeEvent = EventUtility.ConstructEvent(json,
                    Request.Headers["Stripe-Signature"], secret);

                PaymentIntent intent = null;
                Session session = null;
                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    session = (Session)stripeEvent.Data.Object;
                    intent = (PaymentIntent)stripeEvent.Data.Object;


                    OrderHeader orderHeader = await _dbOrderHeader.GetAsync(u => u.SessionId == session.Id && u.OrderStatus == "pending", includeProperties: "ApplicationUser");
                    if (orderHeader != null)
                    {
                        orderHeader.OrderStatus = "completed";
                        orderHeader.PaymentStatus = "completed";
                        await _dbOrderHeader.SaveAsync();
                    }

                    _logger.LogInformation("Completed SessionId: {ID}", session.Id);
                }

                else if (stripeEvent.Type == Events.CheckoutSessionExpired)
                {
                    session = (Session)stripeEvent.Data.Object;
                    
                    OrderHeader orderHeader = await _dbOrderHeader.GetAsync(u => u.SessionId == session.Id && u.OrderStatus == "pending", tracked: false);
                    var userId = orderHeader.ApplicationUser.Id;
                    
                    var carts = await _dbCart.GetAllAsync(u => u.UserId == userId);
                    await _dbCart.RemoveRangeAsync(carts);

                    if (orderHeader != null && carts != null)
                    {
                        orderHeader.OrderStatus = "failed";
                        orderHeader.PaymentStatus = "failed";
                        await _dbOrderHeader.SaveAsync();
                    }

                    _logger.LogInformation("Failure SessionId: {ID}", session.Id);
                }

                else
                {
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                }

                return new EmptyResult();

            }
            catch (StripeException e)
            {
                return BadRequest();
            }
        }
    }
}
