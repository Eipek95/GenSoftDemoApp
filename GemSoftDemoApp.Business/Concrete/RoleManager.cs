using AutoMapper;
using GemSoftDemoApp.Business.Abstract;
using GemSoftDemoApp.Dto.ResponseDtos;
using GemSoftDemoApp.Dto.UserDtos;
using GemSoftDemoApp.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Business.Concrete
{
    public class RoleManager(RoleManager<AppRole> _roleManager,IMapper _mapper) :IRoleService
    {
        public async Task<MyResponse<string>> CreateRoleAsync(CreateRoleDto createRoleDto)
        {
            AppRole role = _mapper.Map<AppRole>(createRoleDto);
            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                List<string> errors = new();

                foreach (var error in result.Errors)
                    errors.Add(error.Description + "/n");

                return MyResponse<string>.Fail(new ErrorDto(errors, false), 400);
            }
            return MyResponse<string>.Success("Rol Başarıyla Oluşturuldu", 200);

        }

        public Task<MyResponse<string>> AssignRoleAsync(List<AssignRoleDto> assignRoleDto)
        {
            throw new NotImplementedException();
        }

        public async Task<MyResponse<string>> DeleteRoleAsync(int id)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (role is null)
                return MyResponse<string>.Fail(new ErrorDto("Rol Bulunamadı", false), 404);

            await _roleManager.DeleteAsync(role);
            return MyResponse<string>.Success("Rol Silindi", 200);
        }

        public  async Task<MyResponse<List<AppRole>>> GetAll()
        {
            var values = await _roleManager.Roles.ToListAsync();
            if (!values.Any()) return MyResponse<List<AppRole>>.Fail(new ErrorDto("Rol Bulunamadı",false),404);

            return MyResponse<List<AppRole>>.Success(values, 200);
        }
    }
}
