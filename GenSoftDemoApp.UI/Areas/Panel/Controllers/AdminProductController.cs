using GenSoftDemoApp.UI.Models;
using GenSoftDemoApp.UI.Services.TokenServices;
using GenSoftDemoApp.UI.ViewModels.CategoryViewModels;
using GenSoftDemoApp.UI.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GenSoftDemoApp.UI.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize(Roles = "Admin")]
    public class AdminProductController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;

        public AdminProductController(IHttpClientFactory clientFactory, ITokenService tokenService)
        {
            _client = clientFactory.CreateClient("GemSoftAppClient");
            _tokenService = tokenService;
        }
        public async Task CategoryDropdown()
        {

            var categoryList = await _client.GetFromJsonAsync<ResponseModel<List<CategoryViewModel>>>("Categories/GetAll/");

            List<SelectListItem> categories = (from x in categoryList.data
                                               select new SelectListItem
                                               {
                                                   Text = x.Title,
                                                   Value = x.Id.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _client.GetFromJsonAsync<ResponseModel<List<ProductViewModel>>>("Products/GetAllWithCategory");
            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);

                return View();
            }
            List<ProductViewModel> products = response.data;
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await CategoryDropdown();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {

            var result = await _client.PostAsJsonAsync("Products/Create", model);
            var response = await result.Content.ReadFromJsonAsync<ResponseModel<NoDataViewModel>>();

            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);

                await CategoryDropdown();
                return View(model);
            }
            return RedirectToAction("GetAll", "AdminProduct", new { Area = "panel" });
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            await CategoryDropdown();
            var response = await _client.GetFromJsonAsync<ResponseModel<ProductViewModel>>("Products/GetById/" + id);
            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);

                return View();
            }
            var category = response.data;
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductViewModel model)
        {
            var result = await _client.PutAsJsonAsync<UpdateProductViewModel>("Products/Update", model);
            var response = await result.Content.ReadFromJsonAsync<ResponseModel<NoDataViewModel>>();
            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);
                await CategoryDropdown();
                return View(model);
            }
            return RedirectToAction("GetAll", "AdminProduct", new { Area = "panel" });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _client.DeleteAsync("Products/Delete/" + id);
            var response = await result.Content.ReadFromJsonAsync<ResponseModel<NoDataViewModel>>();

            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);

                return View();
            }
            return RedirectToAction("GetAll", "AdminProduct", new { Area = "panel" });
        }
    }
}
