
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopFlickerAPI.Models
{
    public class ShoppingCart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Products")]
        [ValidateNever]
        public int ProductId { get; set; }
        public Product Products { get; set; }

        [ForeignKey("Users")]
        [ValidateNever]

        public int UserId { get; set; }
        public ApplicationUser Users{ get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }
}
