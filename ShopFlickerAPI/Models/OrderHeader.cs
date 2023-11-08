using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopFlickerAPI.Models
{
    public class OrderHeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public double OrderTotal { get; set; }
        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public string? SessionId { get; set; }
        public string? PaymentIntentId { get; set; }

        //[Required]
        //public string Name { get; set; }
        //[Required]
        //public string PhoneNumber { get; set; }
        //[Required]
        //public string StreetAddress { get; set; }
        //[Required]
        //public string City { get; set; }
        //[Required]
        //public string State { get; set; }
        //[Required]
        //public string PostalCode { get; set; }
    }
}

