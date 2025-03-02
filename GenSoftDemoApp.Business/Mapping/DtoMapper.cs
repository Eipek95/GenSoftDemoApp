using AutoMapper;
using GenSoftDemoApp.Dto.CategoryDtos;
using GenSoftDemoApp.Dto.OrderDetailDtos;
using GenSoftDemoApp.Dto.OrderDtos;
using GenSoftDemoApp.Dto.ProductDtos;
using GenSoftDemoApp.Dto.UserDtos;
using GenSoftDemoApp.Entity.Entities;

namespace GenSoftDemoApp.API.Mapping
{
    public class DtoMapper:Profile
    {
        public DtoMapper()
        {
         
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<Product,CreateProductDto>().ReverseMap();
            CreateMap<Product,UpdateProductDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();

            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<AppRole, CreateRoleDto>().ReverseMap();
        }
    }
}
