using GemSoftDemoApp.UI.Controllers;
using GemSoftDemoApp.UI.Models;
using GemSoftDemoApp.UI.ViewModels;
using GemSoftDemoApp.UI.ViewModels.CategoryViewModels;
using GemSoftDemoApp.UI.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GemSoftDemoApp.UI.ViewComponents.UILayout
{
    public class _BestSellersProductComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _BestSellersProductComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("GemSoftAppClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _client.GetFromJsonAsync<ResponseModel<List<ProductViewModel>>>("Products/GetAll");
            if (!response.data.Any())
            {
                return View(new List<ProductViewModel>());
            }
            var random = new Random();
            var selectedProducts = response.data.OrderBy(x => random.Next()).Take(6).ToList();
            return View(selectedProducts);
        }
    }
}
