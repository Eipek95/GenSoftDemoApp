using GenSoftDemoApp.UI.Helpers;
using GenSoftDemoApp.UI.Models;
using GenSoftDemoApp.UI.ViewModels.CategoryViewModels;
using GenSoftDemoApp.UI.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.UI.Controllers;

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
                CategoryId = p.CategoryId,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Category = new CategoryViewModel { Id = c.Id, Title = c.Title }
            }))
            .AsQueryable();

        if (price > 0)
            allProducts = allProducts.Where(x => x.Price <= price);
        if (categoryId > 0)
            allProducts = allProducts.Where(x => x.CategoryId == categoryId);


        int pageSize = 9;
        int totalRecords = allProducts.Count();
        int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

        var pagedProducts = allProducts
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        // Kategorilere g�re grupla, her kategoride sadece o sayfadaki �r�nler olacak
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

        return View(result);
    }

    [HttpGet]
    public async Task<IActionResult> Detail(int productId)
    {
        var response = await _client.GetFromJsonAsync<ResponseModel<ProductViewModel>>("Products/GetById/" + productId);

        if (response.error is not null)
        {
            foreach (var item in response.error.errors)
                ModelState.AddModelError("", item);

            return View();
        }

        List<ProductDetailCommentViewModel> comments = ProductDetailCommentViewModel.GenerateRandomComments(); // Yorumlar� olu�tur

        ProductDetailPageViewModel viewModel = new ProductDetailPageViewModel
        {
            Product = response.data,
            Comments = comments
        };


        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Contact()
    {
        return View();
    }
}