using GenSoftDemoApp.UI.Models;
using GenSoftDemoApp.UI.ViewModels.CategoryViewModels;
using GenSoftDemoApp.UI.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.UI.ViewComponents.UILayout
{
    public class _VesitableShopStartComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _VesitableShopStartComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("GemSoftAppClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var response = await _client.GetFromJsonAsync<ResponseModel<List<CategoryViewModel>>>("Categories/GetAllCategoryWithProducts");
            List<ProductViewModel>? vesitables = response.data.Where(x => x.Title.ToLower() == "sebze").Select(x => x.Products).Take(5).FirstOrDefault();
            return View(vesitables);
        }
    }
}
