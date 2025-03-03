using GenSoftDemoApp.Business.Abstract;
using GenSoftDemoApp.Dto.ProductDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController(IProductService _productService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => ActionResultInstance(await _productService.TGetList());
        
        [HttpGet]
        public async Task<IActionResult> GetAllWithCategory() => ActionResultInstance(await _productService.TGetAllProductWithCategory());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => ActionResultInstance(await _productService.TGetById(id));
        
        [HttpGet]
        public async Task<IActionResult> GetAllProductByCategoryId(int categoryId) => ActionResultInstance(await _productService.TGetAllProductByCategoryId(categoryId));

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Create(CreateProductDto productDto) => ActionResultInstance(await _productService.TCreate(productDto));

        [Authorize(Roles ="Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto) => ActionResultInstance(await _productService.TUpdate(updateProductDto));

        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int id) => ActionResultInstance(await _productService.TDelete(id));
    }
}
