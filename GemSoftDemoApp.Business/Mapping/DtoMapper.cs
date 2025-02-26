using AutoMapper;
using GemSoftDemoApp.Dto.BrandDtos;
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
        }
    }
}
