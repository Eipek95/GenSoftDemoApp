using GemSoftDemoApp.UI.Controllers;
using GemSoftDemoApp.UI.Models;
using GemSoftDemoApp.UI.ViewModels;
using GemSoftDemoApp.UI.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GemSoftDemoApp.UI.ViewComponents.UILayout
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
