using GemSoftDemoApp.Dto.ResponseDtos;
using GemSoftDemoApp.Dto.UserDtos;
using GemSoftDemoApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Business.Abstract
{
    public interface IRoleService
    {
        Task<MyResponse<List<AppRole>>> GetAll();
        Task<MyResponse<string>> CreateRoleAsync(CreateRoleDto createRoleDto);
        Task<MyResponse<string>> DeleteRoleAsync(int id);

        //eklenecek
        Task<MyResponse<string>> AssignRoleAsync(List<AssignRoleDto> assignRoleDto);
    }
}
