using GemSoftDemoApp.Business.Abstract;
using GemSoftDemoApp.Dto.ProductDtos;
using Microsoft.AspNetCore.Mvc;

namespace GemSoftDemoApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController(IProductService _productService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => ActionResultInstance(await _productService.TGetList());

        [HttpGet]
        public async Task<IActionResult> GetById(int id) => ActionResultInstance(await _productService.TGetById(id));
        
        [HttpGet]
        public async Task<IActionResult> GetAllProductByBrandId(int brandId) => ActionResultInstance(await _productService.TGetAllProductByBrandId(brandId));

        [HttpGet]
        public async Task<IActionResult> GetAllProductByCategoryId(int categoryId) => ActionResultInstance(await _productService.TGetAllProductByCategoryId(categoryId));

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto productDto) => ActionResultInstance(await _productService.TCreate(productDto));
        
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto) => ActionResultInstance(await _productService.TUpdate(updateProductDto));

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) => ActionResultInstance(await _productService.TDelete(id));
    }
}
