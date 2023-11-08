using ShopFlickerAPI.Models.DTO;

namespace ShopFlickerAPI.Services.IServices
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailDTO emailDTO);
    }
}
