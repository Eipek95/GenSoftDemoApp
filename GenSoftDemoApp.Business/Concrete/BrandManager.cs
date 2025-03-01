using AutoMapper;
using GemSoftDemoApp.Business.Abstract;
using GemSoftDemoApp.DataAccess.Abstract;
using GemSoftDemoApp.Dto;
using GemSoftDemoApp.Dto.BrandDtos;
using GemSoftDemoApp.Dto.ResponseDtos;
using GemSoftDemoApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Business.Concrete
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
