using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopFlickerAPI.Models
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("OrderHeader")]
        public int OrderHeaderId { get; set; }
        public OrderHeader OrderHeader { get; set; }

        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public Product Products { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

    }
}
