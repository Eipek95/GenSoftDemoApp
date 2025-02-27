using AutoMapper;
using GemSoftDemoApp.Dto.BrandDtos;
using GemSoftDemoApp.Dto.CategoryDtos;
using GemSoftDemoApp.Dto.OrderDetailDtos;
using GemSoftDemoApp.Dto.OrderDtos;
using GemSoftDemoApp.Dto.ProductDtos;
using GemSoftDemoApp.Entity.Entities;

namespace GemSoftDemoApp.API.Mapping
{
    public class DtoMapper:Profile
    {
        public DtoMapper()
        {
            CreateMap<Brand,BrandDto>().ReverseMap();
            CreateMap<Brand,CreateBrandDto>().ReverseMap();
            CreateMap<Brand,UpdateBrandDto>().ReverseMap();


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
        }
    }
}
