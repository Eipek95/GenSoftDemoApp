using GemSoftDemoApp.UI.Models;
using GemSoftDemoApp.UI.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GemSoftDemoApp.UI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HttpClient _client;
    public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
    {
        _logger = logger;
        _client = clientFactory.CreateClient("GemSoftAppClient");
    }

    public IActionResult Index()
    {
        return View();
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

        return RedirectToAction("Login", "Home");
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task< IActionResult> Login(LoginViewModel entity)
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
        ModelState.AddModelError("", "Kullanýcý Adý veya Þifre Hatalý");
        return View();
    }
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
