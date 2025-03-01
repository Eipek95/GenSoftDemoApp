using GenSoftDemoApp.Dto.LoginDtos;
using GenSoftDemoApp.Entity.Entities;

namespace GenSoftDemoApp.Business.Abstract
{
    public interface IJwtService
    {
        Task<LoginResponseDto> CreateTokenAsync(AppUser user);

    }
}
