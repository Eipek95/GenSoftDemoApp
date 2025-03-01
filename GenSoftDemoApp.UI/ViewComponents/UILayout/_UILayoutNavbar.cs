using GemSoftDemoApp.UI.Models;
using GemSoftDemoApp.UI.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GemSoftDemoApp.UI.ViewComponents.UILayout
{
    public class _UILayoutNavbar : ViewComponent
    {
        private readonly HttpClient _client;
        public _UILayoutNavbar(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("GemSoftAppClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _client.GetFromJsonAsync<ResponseModel<List<CategoryViewModel>>>("Categories/GetAll");
            if (response.data.Any())
            {
                List<CategoryViewModel> categories = response.data.ToList();

                return View(categories);
            }
            return View();
        }
    }
}
