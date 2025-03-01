using GemSoftDemoApp.UI.Models;
using GemSoftDemoApp.UI.ViewModels.CategoryViewModels;
using GemSoftDemoApp.UI.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GemSoftDemoApp.UI.ViewComponents.UILayout
{
    public class _ProductsCategoryFilterComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _ProductsCategoryFilterComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("GemSoftAppClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _client.GetFromJsonAsync<ResponseModel<List<CategoryViewModel>>>("Categories/GetAllCategoryWithProducts");
            if (response?.data != null)
            {
                var groupedData = response.data
                     .Where(c => c.Products != null && c.Products.Any())
                     .Select(c => new CategoryViewModel
                     {
                         Id = c.Id,
                         Title = c.Title,
                         ProductCount = c.Products!.Count(),
                     }).ToList();

                return View(groupedData);
            }
            return View();
        }
    }
}
