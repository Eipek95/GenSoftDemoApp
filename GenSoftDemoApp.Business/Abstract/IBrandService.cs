using GemSoftDemoApp.Dto;
using GemSoftDemoApp.Dto.BrandDtos;
using GemSoftDemoApp.Dto.ResponseDtos;
using GemSoftDemoApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Business.Abstract
{
    public interface IBrandService: IGenericService<Brand,BrandDto,CreateBrandDto,UpdateBrandDto>
    {
    }
}
