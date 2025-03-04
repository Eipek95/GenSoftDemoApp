using GenSoftDemoApp.Dto.LoginDtos;
using GenSoftDemoApp.Dto.ResponseDtos;
using GenSoftDemoApp.Dto.UserDtos;
using GenSoftDemoApp.Entity.Entities;

namespace GenSoftDemoApp.Business.Abstract
{
    public interface IUserService
    {
        Task<MyResponse<string>> CreateUserAsync(RegisterDto userRegisterDto);
        Task<MyResponse<LoginResponseDto>> LoginAsync(LoginDto userLoginDto);
        Task<MyResponse<List<UserDto>>> GetAllUsersAsync();
        Task<MyResponse<UserDto>> GetUserByIdAsync(int id);
        Task<MyResponse<List<UserRoleDto>>> GetAllUsersWithRoleAsync();
        Task<MyResponse<UserRoleDto>> GetUserWithRoleByIdAsync(int id);
        Task<MyResponse<string>> ChangePassword(ChangePasswordDto model);
        Task LogoutAsync();
    }
}
