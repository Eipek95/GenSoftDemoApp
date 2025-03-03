using GenSoftDemoApp.UI.Models;
using GenSoftDemoApp.UI.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace GenSoftDemoApp.UI.Controllers
{

    public class AuthController : Controller
    {
        private readonly HttpClient _client;
        public AuthController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("GemSoftAppClient");
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel entity)
        {
            var result = await _client.PostAsJsonAsync("Auth/Register", entity);
            var response = await result.Content.ReadFromJsonAsync<ResponseModel<RegisterViewModel>>();

            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);

                return View();
            }

            return RedirectToAction("Login", "Auth");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel entity)
        {
            var result = await _client.PostAsJsonAsync("Auth/Login", entity);
            var response = await result.Content.ReadFromJsonAsync<ResponseModel<LoginResponseViewModel>>();

            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);

                return View(entity);
            }

            var handler = new JwtSecurityTokenHandler();

            var token = handler.ReadJwtToken(response.data.Token);
            var claims = token.Claims.ToList();

            if (response.data.Token != null)
            {
                claims.Add(new Claim("Token", response.data.Token));
                var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                var authProps = new AuthenticationProperties
                {
                    ExpiresUtc = response.data.ExpireDate,
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }
    }
}
