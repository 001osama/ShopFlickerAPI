namespace ShopFlickerAPI.Models.DTO
{
    public class ProductUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Desc { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
