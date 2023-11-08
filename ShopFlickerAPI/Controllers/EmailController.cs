using Microsoft.AspNetCore.Mvc;
using ShopFlickerAPI.Models;
using ShopFlickerAPI.Models.DTO;
using ShopFlickerAPI.Services.IServices;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ShopFlickerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        protected APIResponse _response;
        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
            _response = new APIResponse();
        }


        [HttpPost("subscribe")]
        public async Task<ActionResult<APIResponse>> Subscribe([FromBody] string email)
        {
            try
            {
                var messageBody = $@"<!DOCTYPE html>
                <html>
                <head>
                </head>
                <body>
                    <div style='text-align: center;'>
                        <h1 style='font-size: 24px; font-weight: bold; color: #f95c3c;'>Welcome to Our Newsletter!</h1>
                        <p style='font-size: 16px; color: #43484c;'>Dear User,</p>
                        <p style='font-size: 16px; color: #43484c;'>Thank you for subscribing to our newsletter. You're now part of our community, and we're excited to keep you updated with the latest news, promotions, and more.</p>
                        <p style='font-size: 16px; color: #43484c;'>To ensure you receive our emails, please add our email address to your contacts or safe senders list.</p>
                        <p style='font-size: 14px; color: #979fa7;'>If you didn't subscribe to our newsletter, please ignore this email.</p>
                    </div>
                </body>
                </html>";
            
                await _emailSender.SendEmailAsync(new EmailDTO()
                {
                    Subject = "Welcome to Our Newsletter",
                    Body = messageBody,
                    Email = email
                });
                _response.Result = new { email };
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpPost("emailMessage")]
        public async Task<ActionResult<APIResponse>> EmailMessage([FromBody]EmailMessageDTO emailMessage)
        {
            try
            {
                var messageBody = $@"<!DOCTYPE html>
                                    <html>
                                    <head>
                                    </head>
                                    <body>
                                        <div style='text-align: center;'>
                                            <h1 style='font-size: 24px; font-weight: bold; color: #f95c3c;'>Thank You for Contacting Us!</h1>
                                            <p style='font-size: 16px; color: #43484c;'>Dear {emailMessage.Name},</p>
                                            <p style='font-size: 16px; color: #43484c;'>We've received your message and will get back to you as soon as possible. Here are the details of your inquiry:</p>
                                            <ul style='font-size: 16px; color: #43484c;'>
                                                <li><strong>Name:</strong> {emailMessage.Name}</li>
                                                <li><strong>Email:</strong> {emailMessage.Email}</li>
                                                <li><strong>Message:</strong> {emailMessage.Message}</li>
                                            </ul>
                                            <p style='font-size: 16px; color: #43484c;'>We appreciate your interest in our services and look forward to assisting you. If you have any more questions or concerns, please feel free to reach out to us.</p>
                                            <p style='font-size: 14px; color: #979fa7;'>This is an automated message. Please do not reply to this email.</p>
                                        </div>
                                    </body>
                                    </html>";


                await _emailSender.SendEmailAsync(new EmailDTO()
                {
                    Body = messageBody,
                    Email = emailMessage.Email,
                    Subject = "Thank You for Contacting Us - Your Inquiry"
                });

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch(Exception ex)
            {
                _response.ErrorMessage = new List<string> { ex.ToString() };
                _response.IsSuccess = false;
            }
            return _response;
        }
    }

}
