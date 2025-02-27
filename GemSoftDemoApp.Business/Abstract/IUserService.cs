using Azure;
using GemSoftDemoApp.Dto.LoginDtos;
using GemSoftDemoApp.Dto.ResponseDtos;
using GemSoftDemoApp.Dto.UserDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Business.Abstract
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
