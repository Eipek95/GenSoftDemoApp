using GenSoftDemoApp.Dto.ResponseDtos;
using GenSoftDemoApp.Dto.UserDtos;
using GenSoftDemoApp.Entity.Entities;

namespace GenSoftDemoApp.Business.Abstract
{
    public interface IRoleService
    {
        Task<MyResponse<List<RoleDto>>> GetAll();
        Task<MyResponse<List<AssignRoleDto>>> GetUserForRoleAssignByUserId(int id);
        Task<MyResponse<RoleDto>> GetRoleById(int id);
        Task<MyResponse<string>> CreateRoleAsync(CreateRoleDto createRoleDto);
        Task<MyResponse<string>> UpdateRoleAsync(UpdateRoleDto updateRoleDto);
        Task<MyResponse<string>> DeleteRoleAsync(int id);
        Task<MyResponse<string>> AssignRoleAsync(List<CreateAssignRoleDto> assignRoleDto);
    }
}
