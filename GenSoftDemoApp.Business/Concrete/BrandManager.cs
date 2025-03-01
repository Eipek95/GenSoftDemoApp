using AutoMapper;
using GenSoftDemoApp.Business.Abstract;
using GenSoftDemoApp.DataAccess.Abstract;
using GenSoftDemoApp.Dto.BrandDtos;
using GenSoftDemoApp.Entity.Entities;
namespace GenSoftDemoApp.Business.Concrete
{
    public class BrandManager : GenericManager<Brand,BrandDto,CreateBrandDto,UpdateBrandDto>, IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        public BrandManager(IRepository<Brand> _repository, IMapper _mapper, IBrandRepository brandRepository, IMapper mapper) : base(_repository, _mapper)
        {
            _brandRepository = brandRepository;
            this._mapper = mapper;
        }
    }

}
