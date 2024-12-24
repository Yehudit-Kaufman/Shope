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

            CreateMap<RegisterUserDTO,User>();
            CreateMap<User,RegisterUserDTO > ();
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<AddOrderDTO,Order>();
            CreateMap<OrderItemsDTO,OrderItem>();
            CreateMap<OrderItem,OrderItemsDTO>();



        }
    }
}
