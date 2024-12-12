using AutoMapper;
using DTO;
using Entite;
namespace Shope
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<User, UserDTO>();
            //CreateMap<UserDTO,User>();
            CreateMap<RegisterUserDTO,User>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<AddOrderDTO,Order>();
            CreateMap<OrderItemsDTO,OrderItem>();


        }
    }
}
