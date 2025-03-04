using AutoMapper;
using GenSoftDemoApp.Business.Abstract;
using GenSoftDemoApp.Dto.ResponseDtos;
using GenSoftDemoApp.Dto.UserDtos;
using GenSoftDemoApp.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GenSoftDemoApp.Business.Concrete
{
    public class RoleManager(RoleManager<AppRole> _roleManager, UserManager<AppUser> _userManager, IMapper _mapper) : IRoleService
    {
        public async Task<MyResponse<string>> CreateRoleAsync(CreateRoleDto createRoleDto)
        {
            AppRole role = _mapper.Map<AppRole>(createRoleDto);
            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                List<string> errors = new();

                foreach (var error in result.Errors)
                    errors.Add(error.Description);

                return MyResponse<string>.Fail(new ErrorDto(errors, false), 404);
            }
            return MyResponse<string>.Success("Rol Başarıyla Oluşturuldu", 200);

        }

        public async Task<MyResponse<string>> AssignRoleAsync(List<CreateAssignRoleDto> assignRoleList)
        {
            int userId = assignRoleList.Select(x => x.UserId).FirstOrDefault();
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user is null)
                return MyResponse<string>.Fail(new ErrorDto("Kullanıcı Bulunamadı", false), 404);


            foreach (var item in assignRoleList)
            {
                var role = await _roleManager.FindByIdAsync(item.RoleId.ToString());
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
            }
            return MyResponse<string>.Success("Rol Başarıyla Atandı", 200);

        }

        public async Task<MyResponse<string>> DeleteRoleAsync(int id)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (role is null)
                return MyResponse<string>.Fail(new ErrorDto("Rol Bulunamadı", false), 404);

            await _roleManager.DeleteAsync(role);
            return MyResponse<string>.Success("Rol Silindi", 200);
        }

        public async Task<MyResponse<List<RoleDto>>> GetAll()
        {
            var values = await _roleManager.Roles.ToListAsync();
            if (!values.Any())
                return MyResponse<List<RoleDto>>.Fail(new ErrorDto("Rol Bulunamadı", false), 404);


            var map = _mapper.Map<List<RoleDto>>(values);
            return MyResponse<List<RoleDto>>.Success(map, 200);
        }

        public async Task<MyResponse<string>> UpdateRoleAsync(UpdateRoleDto updateRoleDto)
        {
            AppRole role = _mapper.Map<AppRole>(updateRoleDto);
            var result = await _roleManager.UpdateAsync(role);
            if (!result.Succeeded)
            {
                List<string> errors = new();

                foreach (var error in result.Errors)
                    errors.Add(error.Description);

                return MyResponse<string>.Fail(new ErrorDto(errors, false), 404);
            }
            return MyResponse<string>.Success("Rol Başarıyla Güncellendi", 200);
        }

        public async Task<MyResponse<RoleDto>> GetRoleById(int id)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (role is null)
                return MyResponse<RoleDto>.Fail(new ErrorDto("Rol Bulunamadı", false), 404);

            var map = _mapper.Map<RoleDto>(role);
            return MyResponse<RoleDto>.Success(map, 200);
        }

        public async Task<MyResponse<List<AssignRoleDto>>> GetUserForRoleAssignByUserId(int id)
        {
            
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user is null)
                return MyResponse<List<AssignRoleDto>>.Fail(new ErrorDto("Kullanıcı Bulunamadı", false), 404);

           
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(user);

            List<AssignRoleDto> assignRoleList = new List<AssignRoleDto>();

            foreach (var role in roles)
            {
                var assignRole = new AssignRoleDto();
                assignRole.UserId = user.Id;
                assignRole.RoleId = role.Id;
                assignRole.RoleName = role.Name;
                assignRole.RoleExist = userRoles.Contains(role.Name);

                assignRoleList.Add(assignRole);
            }

            return MyResponse<List<AssignRoleDto>>.Success(assignRoleList, 200);
        }
    }
}
