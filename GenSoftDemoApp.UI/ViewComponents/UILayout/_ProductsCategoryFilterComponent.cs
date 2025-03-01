using GenSoftDemoApp.UI.Models;
using GenSoftDemoApp.UI.ViewModels.CategoryViewModels;
using GenSoftDemoApp.UI.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GenSoftDemoApp.UI.ViewComponents.UILayout
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
