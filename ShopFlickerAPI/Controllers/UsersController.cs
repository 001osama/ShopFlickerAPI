using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopFlickerAPI.Models;
using ShopFlickerAPI.Models.DTO;
using ShopFlickerAPI.Repository.IRepository;
using ShopFlickerAPI.Services.IServices;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace ShopFlickerAPI.Controllers
{
    [Route("api/UsersAuth")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        protected APIResponse _response;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config; 
        private readonly IEmailSender _emailSender;
        public UsersController(
            IUserRepository userRepository, 
            IEmailSender emailSender,
            IConfiguration config, 
            UserManager<ApplicationUser> userManager)
        {
            _emailSender = emailSender;
            _userManager = userManager;
            _userRepo = userRepository;
            _config = config;
            this._response = new();
        }


        [HttpPost("login")]
        public async Task<ActionResult<APIResponse>> Login([FromBody] LoginRequestDTO model)
        {
            var loginResponse = await _userRepo.Login(model);

            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
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
        public async Task<ActionResult<APIResponse>> Register([FromBody] RegistrationRequestDTO model)
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

            if (user.Id == null)
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


        [HttpPost("verifyEmail")]
        [Authorize]
        public async Task<ActionResult<APIResponse>> VerifyEmail()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if(userId == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.Unauthorized;
                return Unauthorized(_response);
            }
            var user = await _userManager.FindByIdAsync(userId);

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            byte[] tokenBytes = Encoding.UTF8.GetBytes(token);
            string encodedToken = Convert.ToBase64String(tokenBytes);


            //another way for link generation
            //var verificationUrl = $"{Request.Scheme}://{Request.Host}/api/UsersAuth/VerifyEmail?token={token}&email={user.Email}";

            var verificationUrl = Url.Action(nameof(ConfirmEmail), "Users", new { token = encodedToken, email = user.Email }, Request.Scheme);
            var messageBody = $@"<!DOCTYPE html>
                                    <html>
                                    <head>
                                    </head>
                                    <body>
                                        <div style='text-align: center;'>
                                            <h1 style='font-size: 24px; font-weight: bold; color: #333;'>Welcome, {user.UserName}!</h1>
                                            <p style='font-size: 16px; color: #666;'>Thank you for registering with our service. We're excited to have you on board.</p>
                                            <p style='font-size: 16px; color: #666;'>To get started, please verify your email by clicking the link below:</p>
                                            <p>
                                                <a href='{verificationUrl}' style='text-decoration: none;'>
                                                    <button style='background-color: #F95C3C; color: #FAFBFC; border-radius: 9999px; padding: 12px 24px; font-size: 16px;'>Verify Email</button>
                                                </a>
                                            </p>
                                            <p style='font-size: 14px; color: #999;'>If you did not register with us, please ignore this email.</p>
                                        </div>
                                    </body>
                                    </html>";

            await _emailSender.SendEmailAsync(new EmailDTO()
            {
                Email = user.Email, //for testing but have to change to user.email later
                Subject = "Email Verification",
                Body = messageBody,
            });

            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }



        [HttpGet("confirmEmail")]
        public async Task<ActionResult<APIResponse>> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessage.Add("User doesnot exists");
                return BadRequest(_response);
            }


            byte[] tokenBytes = Convert.FromBase64String(token);
            string decodedToken = Encoding.UTF8.GetString(tokenBytes);
            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);

            if (result.Succeeded == false)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessage.Add("Internal Server Error");
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
            
        }

        [HttpPost("resetPassword")]
        public async Task<ActionResult<APIResponse>> ResetPassword([FromForm]string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);

                if(user == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                byte[] tokenBytes = Encoding.UTF8.GetBytes(token);
                string encodedToken = Convert.ToBase64String(tokenBytes);
                var frontendUrl = _config.GetValue<string>("FrontendBaseUrl");
                var resetPasswordUrl = $"{frontendUrl}/auth/changePassword?token={encodedToken}&email={user.Email}";
                    //Url.Action(nameof(ChangePassword), "Users", new { encodedToken, email }, Request.Scheme);

                var messageBody = $@"<!DOCTYPE html>
                                        <html>
                                            <head>
                                            </head>
                                            <body>
                                                <div style='text-align: center;'>
                                                    <h1 style='font-size: 24px; font-weight: bold; color: #333;'>Password Reset Request</h1>
                                                    <p style='font-size: 16px; color: #666;'>Hello, {user.UserName}!</p>
                                                    <p style='font-size: 16px; color: #666;'>You have requested a password reset. To proceed, please click the link below:</p>
                                                    <p>
                                                        <a href='{resetPasswordUrl}' style='text-decoration: none;'>
                                                            <button style='background-color: #F95C3C; color: #FAFBFC; border-radius: 9999px; padding: 12px 24px; font-size: 16px;'>Reset Password</button>
                                                        </a>
                                                    </p>
                                                    <p style='font-size: 14px; color: #999;'>If you did not request this password reset, please ignore this email.</p>
                                                </div>
                                            </body>
                                        </html>";



                await _emailSender.SendEmailAsync(new EmailDTO()
                {
                    Body = messageBody,
                    Subject = "Reset Password Request",
                    Email = email, 
                });
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessage = new List<string>() { ex.ToString() };
                _response.IsSuccess = false;
            }
            return _response;

        }

        [HttpPost("changePassword")]
        public async Task<ActionResult<APIResponse>> ChangePassword([FromBody] ResetPasswordDTO resetPasswordRequest)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(resetPasswordRequest.Email);
                if(user == null)
                {
                    _response.StatusCode=HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                byte[] tokenBytes = Convert.FromBase64String(resetPasswordRequest.EncodedToken);
                string originalToken = Encoding.UTF8.GetString(tokenBytes);

                var resetPasswordResult = await _userManager.ResetPasswordAsync(user, originalToken, resetPasswordRequest.Password);
            
                if (resetPasswordResult.Succeeded)
                {
                    _response.IsSuccess = true;
                    _response.StatusCode = HttpStatusCode.OK;
                    return Ok(_response);
                }
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);   
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }

    }
}
