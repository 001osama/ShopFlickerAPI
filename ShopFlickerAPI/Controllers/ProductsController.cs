using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopFlickerAPI.Data;
using ShopFlickerAPI.Models;
using ShopFlickerAPI.Models.DTO;

namespace ShopFlickerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public ProductsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async  Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            return Ok(await _db.Products.ToListAsync());
        }


        [HttpGet("{id:int}",Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async  Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var villa = await _db.Products.FirstOrDefaultAsync( u=> u.Id == id );
            if(villa == null)
            {
                return NotFound();
            }

            return Ok(villa);
        }

        public async Task<ActionResult<ProductDTO>> CreateProduct([FromBody]ProductDTO productDto)
        {
            if (await _db.Products.FirstOrDefaultAsync(u => u.Name.ToLower() == productDto.Name.ToLower()) != null)
            {
                ModelState.AddModelError("Custom Error", "Product Already Exists!");
                return BadRequest();    
            }

            if(productDto == null)
            {
                return BadRequest();
            }

            if(productDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Product model = new Product()
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Amount = productDto.Amount,
                Desc = productDto.Desc,
                CreatedDate = DateTime.Now
            };

            await _db.Products.AddAsync(model);
            _db.SaveChanges();

            return CreatedAtRoute("GetVilla", new { id = model.Id }, productDto);
        }

    }
}
