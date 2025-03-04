using GenSoftDemoApp.Business.Abstract;
using GenSoftDemoApp.Dto.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.API.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolesController(IRoleService _roleService) : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto model) => ActionResultInstance(await _roleService.CreateRoleAsync(model));
        
        [HttpPut]
        public async Task<IActionResult> UpdateRole(UpdateRoleDto model) => ActionResultInstance(await _roleService.UpdateRoleAsync(model));

        [HttpGet]
        public async Task<IActionResult> GetAll() => ActionResultInstance(await _roleService.GetAll()); 
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id) => ActionResultInstance(await _roleService.GetRoleById(id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id) => ActionResultInstance(await _roleService.DeleteRoleAsync(id));

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<CreateAssignRoleDto> assigns) => ActionResultInstance(await _roleService.AssignRoleAsync(assigns));
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserForRoleAssignByUserId(int id) => ActionResultInstance(await _roleService.GetUserForRoleAssignByUserId(id));

    }
}
