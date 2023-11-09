using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopFlickerAPI.Models;
using ShopFlickerAPI.Models.DTO;
using ShopFlickerAPI.Repository.IRepository;
using ShopFlickerAPI.Services.IServices;
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
        private readonly IEmailSender _emailSender;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;
        public WebhookController
            (
                IEmailSender emailSender,
                ILogger<WebhookController> logger,
                IShoppingCartRepository dbCart,
                IOrderHeaderRepository dbOrderHeader,
                IUserRepository userRepo,
                UserManager<ApplicationUser> userManager,
                IConfiguration config
            )
        {
            _logger = logger;
            _dbOrderHeader = dbOrderHeader;
            _dbCart = dbCart;
            _emailSender = emailSender;
            _userManager = userManager;
            _config = config;
        }


        [HttpPost]
        public async Task<ActionResult> Post()
        {
            var secret = _config.GetValue<string>("StripeSettings:WebhookSecret");
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            try
            {

                var stripeEvent = EventUtility.ConstructEvent(json,
                    Request.Headers["Stripe-Signature"], secret);

                Session session = null;

                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    session = (Session)stripeEvent.Data.Object;
                    OrderHeader orderHeader = await _dbOrderHeader.GetAsync(u => u.SessionId == session.Id && u.OrderStatus == "pending", includeProperties: "ApplicationUser");
                    
                    if (orderHeader != null)
                    {
                        orderHeader.OrderStatus = "completed";
                        orderHeader.PaymentStatus = "completed";
                        orderHeader.PaymentIntentId = session.PaymentIntentId;
                        await _dbOrderHeader.SaveAsync();
                        IEnumerable<ShoppingCart> carts;
                        carts = await _dbCart.GetAllAsync(u=>u.UserId == orderHeader.ApplicationUserId);
                        await _dbCart.RemoveRangeAsync(carts);
                        ApplicationUser user = await _userManager.FindByIdAsync(orderHeader.ApplicationUserId);
                        

                        var messageBody = $@"<!DOCTYPE html>
                                            <html>
                                            <head>
                                            </head>
                                            <body>
                                                <div style='text-align: center;'>
                                                    <h1 style='font-size: 24px; font-weight: bold; color: #333;'>Thank you, {user.UserName}, for your order!</h1>
                                                    <p style='font-size: 16px; color: #666;'>Your order has been successfully placed, and we are processing it with care.</p>
                                                    <p style='font-size: 16px; color: #666;'>We appreciate your business and look forward to serving you again.</p>
                                                    <p style='font-size: 14px; color: #999;'>If you have any questions or concerns, please feel free to contact our customer support.</p>
                                                </div>
                                            </body>
                                            </html>";

                        await _emailSender.SendEmailAsync(new EmailDTO
                        {
                            Email = user.Email,
                            Subject = "Order Confirmed",
                            Body = messageBody
                        });

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
