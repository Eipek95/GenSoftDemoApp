using AutoMapper;
using GemSoftDemoApp.Business.Abstract;
using GemSoftDemoApp.Dto.LoginDtos;
using GemSoftDemoApp.Dto.ResponseDtos;
using GemSoftDemoApp.Dto.UserDtos;
using GemSoftDemoApp.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GemSoftDemoApp.Business.Concrete
{
    public class UserManager(UserManager<AppUser> _userManager,
        SignInManager<AppUser> _signInManager,
        IJwtService _jwtService,

        IMapper _mapper) : IUserService
    {


        public async Task<MyResponse<string>> ChangePassword(ChangePasswordDto model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
                return MyResponse<string>.Fail(new ErrorDto("Kullanıcı bulunamadı", false), 400);

            var checkPassword = await _userManager.CheckPasswordAsync(user, model.CurrentPassword);
            if (!checkPassword)
                return MyResponse<string>.Fail(new ErrorDto("Mevcut şifre hatalı", false), 400);

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                List<string> errors = new();

                foreach (var error in result.Errors)
                    errors.Add(error.Description);
                return MyResponse<string>.Fail(new ErrorDto(errors, false), 400);

            }
            return MyResponse<string>.Success("Şifre başarıyla değiştirildi", 200);
        }


        public async Task<MyResponse<string>> CreateUserAsync(RegisterDto userRegisterDto)
        {
            var user = _mapper.Map<AppUser>(userRegisterDto);

            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);

            if (!result.Succeeded)
            {
                List<string> errors = new();

                foreach (var error in result.Errors)
                    errors.Add(error.Description);

                return MyResponse<string>.Fail(new ErrorDto(errors, false), 400);

            }
            await _userManager.AddToRoleAsync(user, "User");
            return MyResponse<string>.Success("Kullanıcı Kaydı Başarılı", 201);

        }


        public async Task<MyResponse<string>> GetUserId()
        {
            var user = await _userManager.FindByNameAsync(ClaimsPrincipal.Current.Identity.Name);
            if (user is null)
                return MyResponse<string>.Fail(new ErrorDto("Kullanıcı Bulunamadı", false), 404);

            return MyResponse<string>.Success(user.Id.ToString(), 200);
        }

        public async Task<MyResponse<LoginResponseDto>> LoginAsync(LoginDto userLoginDto)
        {
            var user = await _userManager.FindByNameAsync(userLoginDto.Username);
            if (user == null)
                return MyResponse<LoginResponseDto>.Fail(new ErrorDto("Bu Kullanıcı Adı Sistemde Kayıtlı Değil", false), 400);


            var result = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password, false, false);
            if (!result.Succeeded)
                return MyResponse<LoginResponseDto>.Fail(new ErrorDto("Kullanıcı Adı veya Şifre Hatalı", false), 400);


            var token = await _jwtService.CreateTokenAsync(user);
            return MyResponse<LoginResponseDto>.Success(token, 200);
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
