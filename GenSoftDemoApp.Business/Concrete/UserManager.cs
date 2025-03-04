using AutoMapper;
using GenSoftDemoApp.Business.Abstract;
using GenSoftDemoApp.Dto.LoginDtos;
using GenSoftDemoApp.Dto.ResponseDtos;
using GenSoftDemoApp.Dto.UserDtos;
using GenSoftDemoApp.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GenSoftDemoApp.Business.Concrete
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

        public async Task<MyResponse<List<UserDto>>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            if (!users.Any())
                return MyResponse<List<UserDto>>.Fail(new ErrorDto("Kullanıcı Bulunamadı", false), 404);

            var map = _mapper.Map<List<UserDto>>(users);
            return MyResponse<List<UserDto>>.Success(map, 200);

        }

        public async Task<MyResponse<List<UserRoleDto>>> GetAllUsersWithRoleAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            if (!users.Any())
                return MyResponse<List<UserRoleDto>>.Fail(new ErrorDto("Kullanıcı Bulunamadı", false), 404);

            List<UserRoleDto> userRoleList = (from user in users
                                              select new UserRoleDto
                                              {
                                                  Id = user.Id,
                                                  UserName = user.UserName,
                                                  Roles = _userManager.GetRolesAsync(user).Result.ToList(),

                                              }).ToList();

            return MyResponse<List<UserRoleDto>>.Success(userRoleList, 200);
        }

        public async Task<MyResponse<UserDto>> GetUserByIdAsync(int id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user is null)
                return MyResponse<UserDto>.Fail(new ErrorDto("Kullanıcı Bulunamadı", false), 404);

            var map= _mapper.Map<UserDto>(user);
            return MyResponse<UserDto>.Success(map, 200);

        }

        public async Task<MyResponse<UserRoleDto>> GetUserWithRoleByIdAsync(int id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user is null)
                return MyResponse<UserRoleDto>.Fail(new ErrorDto("Kullanıcı Bulunamadı", false), 404);

            var userRole = new UserRoleDto
            {
                Id = id,
                Roles=_userManager.GetRolesAsync(user).Result.ToList(),
                UserName=user.UserName
            };
            return MyResponse<UserRoleDto>.Success(userRole, 200);
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
