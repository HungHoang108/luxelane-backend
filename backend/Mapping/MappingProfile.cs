using AutoMapper;
using Luxelane.DTOs;
using Luxelane.Models;
using static Luxelane.DTOs.AddressDto;
using static Luxelane.DTOs.CategoryDto;

namespace Luxelane.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserReadDto>().ReverseMap();
            CreateMap<UserSignUpDto, User>();
            CreateMap<User, UserSignUpReadDto>();
            CreateMap<UserUpdateDto, User>();

            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductUpdateDto, Product>();

            CreateMap<AddressCreateDto, Address>();
            CreateMap<Address, AddressReadDto>();
            CreateMap<AddressUpdateDto, Address>();

            CreateMap<CategoryCreateDto, Category>();
            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryUpdateDto, Category>();

            CreateMap<OrderCreateDto, Order>();
            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderUpdateDto, Order>();

            CreateMap<OrderProductCreateDto, OrderProduct>();
            CreateMap<OrderProduct, OrderProductReadDto>();
            CreateMap<OrderProductUpdateDto, OrderProduct>();
        }
    }
}