using AutoMapper;
using GemSoftDemoApp.Business.Abstract;
using GemSoftDemoApp.DataAccess.Abstract;
using GemSoftDemoApp.Dto.CategoryDtos;
using GemSoftDemoApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Business.Concrete
{
    class CategoryManager : GenericManager<Category, CategoryDto, CreateCategoryDto, UpdateCategoryDto>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryManager(IRepository<Category> _repository, IMapper _mapper, ICategoryRepository categoryRepository, IMapper mapper) : base(_repository, _mapper)
        {
            _categoryRepository = categoryRepository;
            this._mapper = mapper;
        }
    }
}