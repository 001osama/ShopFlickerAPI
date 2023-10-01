
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
        public Product Product { get; set; }

        [ForeignKey("Users")]
        [ValidateNever]

        public string UserId { get; set; }
        public ApplicationUser User{ get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
