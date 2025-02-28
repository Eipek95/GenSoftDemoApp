using GemSoftDemoApp.UI.Helpers;
using GemSoftDemoApp.UI.Models;
using GemSoftDemoApp.UI.ViewModels.CategoryViewModels;
using GemSoftDemoApp.UI.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GemSoftDemoApp.UI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HttpClient _client;
    public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
    {
        _logger = logger;
        _client = clientFactory.CreateClient("GemSoftAppClient");
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> Products(int currentPage = 1, int? price = 0, int? categoryId = 0)
    {
        var response = await _client.GetFromJsonAsync<ResponseModel<List<CategoryViewModel>>>("Categories/GetAllCategoryWithProducts");
        if (response.error is not null)
        {
            return NotFound();
        }


        var allProducts = response.data
            .Where(c => c.Products != null && c.Products.Any())
            .SelectMany(c => c.Products!.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Title = p.Title,
                BrandId = p.BrandId,
                CategoryId = p.CategoryId,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Category = new CategoryViewModel { Id = c.Id, Title = c.Title }
            }))
            .AsQueryable();

        if (price > 0 )
            allProducts = allProducts.Where(x => x.Price <= price);
        if (categoryId > 0)
            allProducts = allProducts.Where(x => x.CategoryId == categoryId);
        //if (price > 0 && categoryId > 0)
        //    allProducts = allProducts.Where(x => x.CategoryId == categoryId && x.Price <= price);


        int pageSize = 9;
        int totalRecords = allProducts.Count();
        int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

        var pagedProducts = allProducts
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        // Kategorilere göre grupla, her kategoride sadece o sayfadaki ürünler olacak
        var groupedData = pagedProducts
            .GroupBy(p => p.Category)
            .Select(g => new CategoryViewModel
            {
                Id = g.Key.Id,
                Title = g.Key.Title,
                Products = g.ToList()
            }).ToList();

        var pageNumbers = Helper.GeneratePageNumbers(totalPages, currentPage);

        var result = new PagedResultListViewModel<CategoryViewModel>
        {
            Data = groupedData,
            CurrentPage = currentPage,
            PageSize = pageSize,
            TotalRecords = totalRecords,
            PageNumbers = pageNumbers,
        };

        if (price > 0) result.Price = price;
        //if (categoryId > 0) result.CategoryId = categoryId;

        return View(result);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
