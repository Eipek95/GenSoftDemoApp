using GemSoftDemoApp.Dto.BrandDtos;
using GemSoftDemoApp.Dto.CategoryDtos;
using GemSoftDemoApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Business.Abstract
{
    public interface ICategoryService : IGenericService<Category, CategoryDto, CreateCategoryDto, UpdateCategoryDto>
    {
    }
}
