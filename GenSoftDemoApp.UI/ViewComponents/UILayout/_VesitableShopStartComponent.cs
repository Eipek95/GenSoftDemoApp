using GemSoftDemoApp.UI.Models;
using GemSoftDemoApp.UI.ViewModels.CategoryViewModels;
using GemSoftDemoApp.UI.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GemSoftDemoApp.UI.ViewComponents.UILayout
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
            List<ProductViewModel>? vesitables = response.data.Where(x => x.Id == 3).Select(x => x.Products).Take(5).FirstOrDefault();
            return View(vesitables);
        }
    }
}
