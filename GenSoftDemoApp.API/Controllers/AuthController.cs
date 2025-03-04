using GenSoftDemoApp.Business.Abstract;
using GenSoftDemoApp.Dto.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController(IUserService _userService) : CustomBaseController
    {

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model) => ActionResultInstance(await _userService.LoginAsync(model));

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model) => ActionResultInstance(await _userService.CreateUserAsync(model));

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model) => ActionResultInstance(await _userService.ChangePassword(model));

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers() => ActionResultInstance(await _userService.GetAllUsersAsync());
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserById(int id) => ActionResultInstance(await _userService.GetUserByIdAsync(id));
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserWithRoleById(int id) => ActionResultInstance(await _userService.GetUserWithRoleByIdAsync(id));
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsersWithRole() => ActionResultInstance(await _userService.GetAllUsersWithRoleAsync());
    }
}
