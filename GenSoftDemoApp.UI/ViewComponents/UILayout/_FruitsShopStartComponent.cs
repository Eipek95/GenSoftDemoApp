using GenSoftDemoApp.UI.Controllers;
using GenSoftDemoApp.UI.Models;
using GenSoftDemoApp.UI.ViewModels;
using GenSoftDemoApp.UI.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.UI.ViewComponents.UILayout
{
    public class _FruitsShopStartComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _FruitsShopStartComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("GemSoftAppClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var response = await _client.GetFromJsonAsync<ResponseModel<List<CategoryViewModel>>>("Categories/GetAllCategoryWithProducts");
            return View(response.data);
        }
    }
}
