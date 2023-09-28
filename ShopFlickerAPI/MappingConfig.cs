using AutoMapper;
using ShopFlickerAPI.Models;
using ShopFlickerAPI.Models.DTO;

namespace ShopFlickerAPI
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductCreateDTO>().ReverseMap();
            CreateMap<ApplicationUser, UserDTO>().ReverseMap(); 
            CreateMap<ShoppingCart, ShoppingCartDTO>().ReverseMap();
            CreateMap<ShoppingCart, ShoppingCartCreateDTO>().ReverseMap();
            CreateMap<ProductUpdateDTO, Product>().ReverseMap();
        }
    }
}
