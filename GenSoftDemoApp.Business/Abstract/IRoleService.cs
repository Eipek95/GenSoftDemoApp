using GenSoftDemoApp.Dto.ResponseDtos;
using GenSoftDemoApp.Dto.UserDtos;
using GenSoftDemoApp.Entity.Entities;

namespace GenSoftDemoApp.Business.Abstract
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
