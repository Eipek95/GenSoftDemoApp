using GenSoftDemoApp.Business.Abstract;
using GenSoftDemoApp.Dto.CategoryDtos;
using GenSoftDemoApp.Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class CategoriesController(ICategoryService _categoryService) : CustomBaseController
    {
        
        [HttpGet]
        public async Task<IActionResult> GetAll()=> ActionResultInstance(await _categoryService.TGetList());
        [HttpGet]
        public async Task<IActionResult> GetAllCategoryWithProducts()=> ActionResultInstance(await _categoryService.TGetAllCategoryWithProducts());

        [HttpGet]
        public async Task<IActionResult> GetById(int id) => ActionResultInstance(await _categoryService.TGetById(id));

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto categoryDto)=> ActionResultInstance(await _categoryService.TCreate(categoryDto));

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto) => ActionResultInstance(await _categoryService.TUpdate(updateCategoryDto));

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) => ActionResultInstance(await _categoryService.TDelete(id));
    }
}
