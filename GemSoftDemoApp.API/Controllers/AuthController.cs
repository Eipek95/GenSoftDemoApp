using AutoMapper;
using GemSoftDemoApp.Business.Abstract;
using GemSoftDemoApp.Dto.UserDtos;
using GemSoftDemoApp.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GemSoftDemoApp.API.Controllers
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
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model) => ActionResultInstance(await _userService.ChangePassword(model));

        [HttpGet()]
        public async Task<IActionResult> GetUserId() => ActionResultInstance(await _userService.GetUserId());

        
    }
}
