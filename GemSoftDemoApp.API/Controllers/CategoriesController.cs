using GemSoftDemoApp.Business.Abstract;
using GemSoftDemoApp.Dto.CategoryDtos;
using GemSoftDemoApp.Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GemSoftDemoApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class CategoriesController(ICategoryService _brandService) : CustomBaseController
    {
        
        [HttpGet]
        public async Task<IActionResult> GetAll()=> ActionResultInstance(await _brandService.TGetList());

        [HttpGet]
        public async Task<IActionResult> GetById(int id) => ActionResultInstance(await _brandService.TGetById(id));

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto brandDto)=> ActionResultInstance(await _brandService.TCreate(brandDto));

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto) => ActionResultInstance(await _brandService.TUpdate(updateCategoryDto));

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) => ActionResultInstance(await _brandService.TDelete(id));
    }
}
