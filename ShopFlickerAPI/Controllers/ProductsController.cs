using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopFlickerAPI.Models;
using ShopFlickerAPI.Models.DTO;
using ShopFlickerAPI.Repository.IRepository;
using System.Net;

namespace ShopFlickerAPI.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly IProductRepository _dbProduct;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProductsController(IMapper mapper, IProductRepository dbProduct,
            IWebHostEnvironment hostEnvironment)
        {
            _dbProduct = dbProduct;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
            this._response = new();
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async  Task<ActionResult<APIResponse>> GetProducts([FromQuery] string? search,int pageSize = 0, int pageNumber= 1)
        {
            try
            {
                IEnumerable<Product> productList;
                productList = await _dbProduct.GetAllAsync(pageSize: pageSize, pageNumber: pageNumber);

                if(!string.IsNullOrEmpty(search))
                {
                    productList = productList.Where(u => u.Name.ToLower() == search.ToLower());
                }
                _response.Result = _mapper.Map<List<ProductDTO>>(productList);
                return Ok(_response);
            }

            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpGet("{id:int}",Name = "GetProduct")]
        [Authorize(Roles = "customer")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async  Task<ActionResult<APIResponse>> GetProduct(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var product = await _dbProduct.GetAsync(u => u.Id == id);
                if (product == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<ProductDTO>(product);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }

            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        //[Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<APIResponse>> CreateProduct([FromForm]ProductCreateDTO createDto)
        {
            try
            {
                if (await _dbProduct.GetAsync( u=> u.Name == createDto.Name) != null)
                {
                    ModelState.AddModelError("Custom Error", "Product Already Exists!");
                    return BadRequest();    
                }


                if (createDto.ImageFile == null)
                {
                    ModelState.AddModelError("ErrorMessage", "Product Image is required");
                    return BadRequest(ModelState);
                }

                string wwwRootPath = _hostEnvironment.WebRootPath;

                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images\products");
                var extension = Path.GetExtension(createDto.ImageFile.FileName);

                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    await createDto.ImageFile.CopyToAsync(fileStreams);
                }

                if (createDto == null)
                {
                    return BadRequest();
                }

                Product product = _mapper.Map<Product>(createDto);
                product.ImageUrl = @"\images\products\" + fileName + extension;
                product.CreatedDate = DateTime.Now;

                await _dbProduct.CreateAsync(product);
                _response.Result = _mapper.Map<ProductDTO>(product);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetVilla", new { id = product.Id }, _response);
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;
        }


        [HttpDelete("{id:int}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<ActionResult<APIResponse>> DeleteProduct(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                var product = await _dbProduct.GetAsync(u => u.Id == id);
                
                if (product == null)
                {
                    return NotFound();
                }

                await _dbProduct.RemoveAsync(product);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpPut("{id:int}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<ActionResult<APIResponse>> UpdateProduct(int id, [FromBody] ProductDTO updateDto)
        {
            try
            {
                if(id == 0 || id != updateDto.Id)
                {
                    return BadRequest();
                }

                Product model = _mapper.Map<Product>(updateDto);

                model.UpdatedDate = DateTime.Now;
                await _dbProduct.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
                    
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;

        }
    }
}
