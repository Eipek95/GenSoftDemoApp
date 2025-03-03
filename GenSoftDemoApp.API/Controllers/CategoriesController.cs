using GenSoftDemoApp.Business.Abstract;
using GenSoftDemoApp.Dto.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController(ICategoryService _categoryService) : CustomBaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetAll() => ActionResultInstance(await _categoryService.TGetList());
        [HttpGet]
        public async Task<IActionResult> GetAllCategoryWithProducts() => ActionResultInstance(await _categoryService.TGetAllCategoryWithProducts());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => ActionResultInstance(await _categoryService.TGetById(id));

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateCategoryDto categoryDto) => ActionResultInstance(await _categoryService.TCreate(categoryDto));

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto) => ActionResultInstance(await _categoryService.TUpdate(updateCategoryDto));

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => ActionResultInstance(await _categoryService.TDelete(id));
    }
}
