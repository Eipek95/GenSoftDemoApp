using GenSoftDemoApp.UI.Models;
using GenSoftDemoApp.UI.Services.TokenServices;
using GenSoftDemoApp.UI.ViewModels;
using GenSoftDemoApp.UI.ViewModels.CategoryViewModels;
using GenSoftDemoApp.UI.ViewModels.OrderViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.UI.Areas.Panel.Controllers
{
    [Area("Panel")]
    public class AdminCategoryController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;

        public AdminCategoryController(IHttpClientFactory clientFactory, ITokenService tokenService)
        {
            _client = clientFactory.CreateClient("GemSoftAppClient");
            _tokenService = tokenService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _client.GetFromJsonAsync<ResponseModel<List<CategoryViewModel>>>("Categories/GetAll/");
            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);

                return View();
            }
            List<CategoryViewModel> categories = response.data;
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
           return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryViewModel model)
        {

            var result = await _client.PostAsJsonAsync("Categories/Create",model);
            var response = await result.Content.ReadFromJsonAsync<ResponseModel<NoDataViewModel>>();

            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);

                return View();
            }
            return RedirectToAction("GetAll","AdminCategory", new {Area="panel"});
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var response = await _client.GetFromJsonAsync<ResponseModel<CategoryViewModel>>("Categories/GetById/" + id);
            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);

                return View();
            }
            var category =response.data;
            return View(category);
        }
        [HttpPost]
        public async  Task<IActionResult> Update(UpdateCategoryViewModel model)
        {
            var result = await _client.PutAsJsonAsync<UpdateCategoryViewModel>("Categories/Update", model);
            var response = await result.Content.ReadFromJsonAsync<ResponseModel<NoDataViewModel>>();
            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);

                return View();
            }
            return RedirectToAction("GetAll", "AdminCategory", new { Area = "panel" });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result=await _client.DeleteAsync("Categories/Delete/" + id);
            var response = await result.Content.ReadFromJsonAsync<ResponseModel<NoDataViewModel>>();

            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);

                return View();
            }
            return RedirectToAction("GetAll", "AdminCategory", new { Area = "panel" });
        }
    }
}
