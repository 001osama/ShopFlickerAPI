using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopFlickerAPI.Models;
using ShopFlickerAPI.Models.DTO;
using ShopFlickerAPI.Repository.IRepository;
using System.Net;
using System.Security.Claims;

namespace ShopFlickerAPI.Controllers
{
    [Route("api/UsersAuth")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        protected APIResponse _response;
        public UsersController(IUserRepository userRepository)
        {
            _userRepo = userRepository;
            this._response = new();
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model) 
        {
            var loginResponse = await _userRepo.Login(model);
            if(loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessage.Add("Username or password is incorrect");
                return BadRequest(_response);
            }
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = loginResponse;
            return Ok(_response);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model) 
        {
            bool ifUsernameUnique = _userRepo.IsUniqueUser(model.Username);
            if (!ifUsernameUnique) 
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessage.Add("User already exists");
                _response.IsSuccess = false;
                return BadRequest(_response);
            }

            var user = await _userRepo.Register(model);
            if (user == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessage.Add("Error while registering");
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }

    }
}
