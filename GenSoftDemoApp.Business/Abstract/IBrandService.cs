using GenSoftDemoApp.Dto.BrandDtos;
using GenSoftDemoApp.Entity.Entities;

namespace GenSoftDemoApp.Business.Abstract
{
    public interface IBrandService: IGenericService<Brand,BrandDto,CreateBrandDto,UpdateBrandDto>
    {
    }
}
