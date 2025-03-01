using AutoMapper;
using GenSoftDemoApp.Business.Abstract;
using GenSoftDemoApp.DataAccess.Abstract;
using GenSoftDemoApp.Dto.ProductDtos;
using GenSoftDemoApp.Dto.ResponseDtos;
using GenSoftDemoApp.Entity.Entities;

namespace GenSoftDemoApp.Business.Concrete
{
    class ProductManager : GenericManager<Product, ProductDto, CreateProductDto, UpdateProductDto>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductManager(IRepository<Product> _repository, IMapper _mapper, IProductRepository productRepository, IMapper mapper) : base(_repository, _mapper)
        {
            _productRepository = productRepository;
            this._mapper = mapper;
        }

        public async Task<MyResponse< List<ProductDto>>> TGetAllProductByBrandId(int brandId)
        {
            List<Product> products = await _productRepository.GetAllProductByBrandId(brandId);
            var map=_mapper.Map<List<ProductDto>>(products);
            if (!products.Any()) return MyResponse<List<ProductDto>>.Fail(new ErrorDto($"{brandId} markaya ait ürün bulunumadı",false),404);

            return MyResponse<List<ProductDto>>.Success(map,200);
        }

        public async Task<MyResponse<List<ProductDto>>> TGetAllProductByCategoryId(int categoryId)
        {
            List<Product> products = await _productRepository.GetAllProductByCategoryId(categoryId);
            var map = _mapper.Map<List<ProductDto>>(products);
            if (!products.Any()) return MyResponse<List<ProductDto>>.Fail(new ErrorDto($"{categoryId} kategoriye ait ürün bulunumadı", false), 404);

            return MyResponse<List<ProductDto>>.Success(map, 200);
        }
    }
}
