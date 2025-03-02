using GenSoftDemoApp.UI.Models;
using GenSoftDemoApp.UI.Services.SessionServices;
using GenSoftDemoApp.UI.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.UI.ViewComponents.UILayout
{
    public class _UILayoutNavbar : ViewComponent
    {
        private readonly HttpClient _client;
        private readonly CartService _cartService;

        public _UILayoutNavbar(IHttpClientFactory clientFactory, CartService cartService)
        {
            _client = clientFactory.CreateClient("GemSoftAppClient");
            _cartService = cartService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _client.GetFromJsonAsync<ResponseModel<List<CategoryViewModel>>>("Categories/GetAll");
            ViewBag.Count = _cartService.GetCartItemCount();
            if (response.data.Any())
            {
                List<CategoryViewModel> categories = response.data.ToList();
                return View(categories);
            }
            
            return View();
        }
    }
}
