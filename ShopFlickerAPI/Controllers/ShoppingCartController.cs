using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShopFlickerAPI.Models;
using ShopFlickerAPI.Models.DTO;
using ShopFlickerAPI.Repository.IRepository;
using System.Net;
using System.Security.Claims;

namespace ShopFlickerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartRepository _dbCart;
        private readonly IProductRepository _dbProduct;
        private readonly IMapper _mapper;
        private APIResponse _response;
        public ShoppingCartController(IShoppingCartRepository dbCart, IMapper mapper, IProductRepository dbProduct) 
        {
            _dbCart = dbCart;
            _dbProduct = dbProduct;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAllItems()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if(userId == null || userId.IsNullOrEmpty())
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessage.Add("User is not LoggedIn");
                    _response.StatusCode = HttpStatusCode.Unauthorized;
                    return Unauthorized(_response);
                }
                IEnumerable<ShoppingCart> cartList;
                cartList = await _dbCart.GetAllAsync(u=> u.UserId == userId, "Product");
                _response.Result = _mapper.Map<List<ShoppingCartDTO>>(cartList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex) 
            {
                _response.ErrorMessage = new List<string>() { ex.Message };
                _response.IsSuccess = false;
            }
            return _response;
            
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<ActionResult<APIResponse>> AddToCart([FromBody] ShoppingCartCreateDTO createDTO)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null || userId.IsNullOrEmpty())
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessage.Add("User is not LoggedIn");
                    _response.StatusCode = HttpStatusCode.Unauthorized;
                    return Unauthorized(_response);
                }

                if (createDTO.ProductId == 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var product = await _dbProduct.GetAsync(u => u.Id == createDTO.ProductId);
                if(product == null)
                {
                    ModelState.AddModelError("CustomError", "Product doesnot exist");
                    return BadRequest(ModelState);
                }
                var cart = await _dbCart.GetAsync(u => u.ProductId == createDTO.ProductId && u.UserId == userId);
                if ( cart != null)
                {
                    cart.Quantity += createDTO.Quantity;
                    cart.TotalPrice = cart.Quantity * product.Price;
                    await _dbCart.UpdateAsync(cart);
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.IsSuccess = true;
                    return Ok(_response);
                }
                var model = _mapper.Map<ShoppingCart>(createDTO);
                model.UserId = userId;
                model.TotalPrice = product.Price * model.Quantity;
                await _dbCart.CreateAsync(model);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.Message };
            }
            return _response;
        }

        [Authorize]
        [HttpPut("IncrementCount/{cartId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<ActionResult<APIResponse>> IncrementCount(int cartId)
        {
            try
            {
                if (cartId == 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var cart = await _dbCart.GetAsync(u => u.Id == cartId,true, "Product");

                if (cart == null) 
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                cart.Quantity = cart.Quantity + 1;
                cart.TotalPrice = cart.Product.Price * cart.Quantity;
                await _dbCart.UpdateAsync(cart);
                _response.IsSuccess = true;
                _response.StatusCode=HttpStatusCode.OK;
                _response.Result = _mapper.Map<ShoppingCartDTO>(cart);
                Ok(_response);

            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.Message };
            }
            return _response;
        }

        [Authorize]
        [HttpPut("DecrementCount/{cartId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<ActionResult<APIResponse>> DecrementCount(int cartId)
        {
            try
            {
                if (cartId == 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var cart = await _dbCart.GetAsync(u => u.Id == cartId, true, "Product");

                if (cart == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                cart.Quantity = cart.Quantity - 1;
                cart.TotalPrice = cart.Product.Price * cart.Quantity;
                await _dbCart.UpdateAsync(cart);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<ShoppingCartDTO>(cart);
                Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.Message };
            }
            return _response;
        }


        [Authorize]
        [HttpDelete("{cartId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<APIResponse>> RemoveItem(int cartId)
        {
            try
            {
                if(cartId == 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var cart = await _dbCart.GetAsync(u => u.Id == cartId);
                if(cart == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessage.Add("Cart Doesnot Exists");
                    return BadRequest(_response);
                }

                await _dbCart.RemoveAsync(cart);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.Message };
            }
            return _response;
        }
    }
}
