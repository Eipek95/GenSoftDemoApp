using GemSoftDemoApp.Dto.ProductDtos;
using GemSoftDemoApp.Dto.ResponseDtos;
using GemSoftDemoApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Business.Abstract
{
    public interface IProductService:IGenericService<Product, ProductDto, CreateProductDto, UpdateProductDto>
    {
        Task<MyResponse<List<ProductDto>>> TGetAllProductByBrandId(int brandId);
        Task<MyResponse<List<ProductDto>>> TGetAllProductByCategoryId(int categoryId);
    }
}
