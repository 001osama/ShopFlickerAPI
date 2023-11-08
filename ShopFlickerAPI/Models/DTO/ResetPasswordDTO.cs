using System.ComponentModel.DataAnnotations;

namespace ShopFlickerAPI.Models.DTO
{
    public class ResetPasswordDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match!!")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string EncodedToken { get; set; }
    }
}
