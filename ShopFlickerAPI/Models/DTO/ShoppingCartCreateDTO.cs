namespace ShopFlickerAPI.Models.DTO
{
    public class ShoppingCartCreateDTO
    {
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public int Count { get; set; }
    }
}
