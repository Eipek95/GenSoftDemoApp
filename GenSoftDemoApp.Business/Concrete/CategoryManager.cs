using AutoMapper;
using GenSoftDemoApp.Business.Abstract;
using GenSoftDemoApp.DataAccess.Abstract;
using GenSoftDemoApp.Dto.CategoryDtos;
using GenSoftDemoApp.Dto.ResponseDtos;
using GenSoftDemoApp.Entity.Entities;

namespace GenSoftDemoApp.Business.Concrete
{
   public class CategoryManager : GenericManager<Category, CategoryDto, CreateCategoryDto, UpdateCategoryDto>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryManager(IRepository<Category> _repository, IMapper _mapper, ICategoryRepository categoryRepository, IMapper mapper) : base(_repository, _mapper)
        {
            _categoryRepository = categoryRepository;
            this._mapper = mapper;
        }

        public async Task<MyResponse<List<CategoryDto>>> TGetAllCategoryWithProducts()
        {
            var categories = await _categoryRepository.GetAllCategoryWithProducts();
            if (!categories.Any())
                return MyResponse<List<CategoryDto>>.Fail(new ErrorDto("Kategori Bulunamadı", false), 404);
            var map = _mapper.Map<List<CategoryDto>>(categories);
            return MyResponse<List<CategoryDto>>.Success(map, 200);


        }
    }
}