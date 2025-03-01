using GenSoftDemoApp.UI.Models;
using GenSoftDemoApp.UI.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.UI.ViewComponents.UILayout
{
    public class _ProductsFeaturedFilterComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _ProductsFeaturedFilterComponent(IHttpClientFactory clientFactory)
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
            var selectedProducts = response.data.OrderBy(x => random.Next()).Take(3).ToList();
            return View(selectedProducts);
        }
    }
}
