using GenSoftDemoApp.Dto.ProductDtos;
using GenSoftDemoApp.Dto.ResponseDtos;
using GenSoftDemoApp.Entity.Entities;

namespace GenSoftDemoApp.Business.Abstract
{
    public interface IProductService:IGenericService<Product, ProductDto, CreateProductDto, UpdateProductDto>
    {
        Task<MyResponse<List<ProductDto>>> TGetAllProductByBrandId(int brandId);
        Task<MyResponse<List<ProductDto>>> TGetAllProductByCategoryId(int categoryId);
    }
}
