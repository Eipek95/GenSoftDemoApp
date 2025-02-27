using GemSoftDemoApp.Business.Abstract;
using GemSoftDemoApp.Dto.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GemSoftDemoApp.API.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolesController(IRoleService _roleService) : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto model) => ActionResultInstance(await _roleService.CreateRoleAsync(model));

        [HttpPost]
        public async Task<IActionResult> GetAll() => ActionResultInstance(await _roleService.GetAll());

        [HttpPost]
        public async Task<IActionResult> DeleteRole(int id) => ActionResultInstance(await _roleService.DeleteRoleAsync(id));

        [HttpGet]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> assigns) => ActionResultInstance(await _roleService.AssignRoleAsync(assigns));

    }
}
