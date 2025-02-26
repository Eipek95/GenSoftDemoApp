using AutoMapper;
using GemSoftDemoApp.Business.Abstract;
using GemSoftDemoApp.Dto.UserDtos;
using GemSoftDemoApp.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GemSoftDemoApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController(UserManager<AppUser> _userManager,
        SignInManager<AppUser> _signInManager,
        IJwtService _jwtService,
        IMapper _mapper) : ControllerBase
    {

        [HttpPost()]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
                return BadRequest("Bu Kullanıcı Adı Sistemde Kayıtlı Değil");


            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded)
                return BadRequest("Kullanıcı Adı veya Şifre Hatalı");


            var token = await _jwtService.CreateTokenAsync(user);
            return Ok(token);
        }

        [HttpGet()]
        public async Task<IActionResult> GetUserId()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return Ok(user.Id);
        }
    }
}
