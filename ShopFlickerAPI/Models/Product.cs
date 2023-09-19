using System.ComponentModel.DataAnnotations.Schema;

namespace ShopFlickerAPI.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        //public string ImageUrl { get; set; } 
        public double Amount{ get; set; }
        public string Desc { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
