using GenSoftDemoApp.Dto.CategoryDtos;
using GenSoftDemoApp.Dto.ResponseDtos;
using GenSoftDemoApp.Entity.Entities;

namespace GenSoftDemoApp.Business.Abstract
{
    public interface ICategoryService : IGenericService<Category, CategoryDto, CreateCategoryDto, UpdateCategoryDto>
    {
        Task<MyResponse<List<CategoryDto>>> TGetAllCategoryWithProducts();

    }
}
