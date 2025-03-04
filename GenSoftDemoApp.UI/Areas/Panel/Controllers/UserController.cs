using GenSoftDemoApp.UI.Models;
using GenSoftDemoApp.UI.Services.TokenServices;
using GenSoftDemoApp.UI.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.UI.Areas.Panel.Controllers
{
    [Authorize]
    [Area("Panel")]
    public class UserController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;

        public UserController(IHttpClientFactory clientFactory, ITokenService tokenService)
        {
            _client = clientFactory.CreateClient("GemSoftAppClient");
            _tokenService = tokenService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _client.GetFromJsonAsync<ResponseModel<List<UserRoleViewModel>>>("Auth/GetAllUsersWithRole/");
            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);

                return View();
            }
            List<UserRoleViewModel> users = response.data;
            return View(users);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            ViewBag.UserId = id;
            var response = await _client.GetFromJsonAsync<ResponseModel<List<AssignRoleViewModel>>>("Roles/GetUserForRoleAssignByUserId/" + id);
            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);
                return View();
            }
            List<AssignRoleViewModel> assignRoles = response.data;
            return View(assignRoles);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<CreateAssignRoleViewModel> model)
        {
            var result = await _client.PostAsJsonAsync("Roles/AssignRole", model);
            var response = await result.Content.ReadFromJsonAsync<ResponseModel<string>>();

            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);
                return View(model);
            }

            return RedirectToAction("Index", "User", new { Area = "Panel" });
        }

        [HttpGet]
        public IActionResult PasswordChange()
        {
            ViewBag.userName = _tokenService.GetUsername;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PasswordChange(ChangePasswordViewModel model)
        {
            var result = await _client.PostAsJsonAsync("Auth/ChangePassword", model);
            var response = await result.Content.ReadFromJsonAsync<ResponseModel<string>>();

            if (response.error is not null)
            {
                ViewBag.userName = _tokenService.GetUsername;
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);
                return View(model);
            }

            return RedirectToAction("Logout", "Auth", new { Area = "" });
        }
    }
}
