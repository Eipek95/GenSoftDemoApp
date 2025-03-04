using GenSoftDemoApp.UI.Models;
using GenSoftDemoApp.UI.Services.TokenServices;
using GenSoftDemoApp.UI.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.UI.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize(Roles = "Admin")]
    public class AdminRoleController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;

        public AdminRoleController(IHttpClientFactory clientFactory, ITokenService tokenService)
        {
            _client = clientFactory.CreateClient("GemSoftAppClient");
            _tokenService = tokenService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetRoles()
        {
            var response = await _client.GetFromJsonAsync<ResponseModel<List<RoleViewModel>>>("Roles/GetAll");

            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);

                return View();
            }
            List<RoleViewModel> roles = response.data;
            return View(roles);
        }

        [HttpGet]

        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            var result = await _client.PostAsJsonAsync("Roles/CreateRole", model);
            var response = await result.Content.ReadFromJsonAsync<ResponseModel<string>>();

            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);
                return View(model);
            }

            return RedirectToAction("GetRole", "User", new { Area = "" });
        }
        [HttpGet]

        public async Task<IActionResult> UpdateRole(int id)
        {
            var response = await _client.GetFromJsonAsync<ResponseModel<RoleViewModel>>("Roles/GetRoleById/" + id);
            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);

                return View();
            }
            UpdateRoleViewModel role = new()
            {
                Id = response.data.Id,
                Name = response.data.Name,
            };
            return View(role);

        }
        [HttpPost]

        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel model)
        {

            var updateResult = await _client.PutAsJsonAsync<UpdateRoleViewModel>("Roles/UpdateRole", model);
            var updateResponse = await updateResult.Content.ReadFromJsonAsync<ResponseModel<string>>();

            if (updateResponse.error is not null)
            {
                foreach (var item in updateResponse.error.errors)
                    ModelState.AddModelError("", item);

                return View();
            }
            return RedirectToAction("GetRoles", "User", new { Area = "panel" });
        }

        [HttpGet]

        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await _client.DeleteAsync("Roles/DeleteRole/" + id);
            var response = await result.Content.ReadFromJsonAsync<ResponseModel<string>>();

            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);

                return View();
            }
            return RedirectToAction("GetRoles", "User", new { Area = "panel" });
        }
    }
}
