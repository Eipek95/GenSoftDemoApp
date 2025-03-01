using GenSoftDemoApp.Dto.LoginDtos;
using GenSoftDemoApp.Dto.ResponseDtos;
using GenSoftDemoApp.Dto.UserDtos;

namespace GenSoftDemoApp.Business.Abstract
{
    public interface IUserService
    {
        Task<MyResponse<string>> CreateUserAsync(RegisterDto userRegisterDto);

        Task<MyResponse<LoginResponseDto>> LoginAsync(LoginDto userLoginDto);
        Task LogoutAsync();

        Task<MyResponse<string>> ChangePassword(ChangePasswordDto model);
        
        Task<MyResponse<string>> GetUserId();
    }
}
