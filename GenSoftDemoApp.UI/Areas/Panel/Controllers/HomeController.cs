using GenSoftDemoApp.UI.Enums;
using GenSoftDemoApp.UI.Extensions;
using GenSoftDemoApp.UI.Models;
using GenSoftDemoApp.UI.Services.TokenServices;
using GenSoftDemoApp.UI.ViewModels.OrderViewModels;
using GenSoftDemoApp.UI.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.UI.Areas.Panel.Controllers
{
    [Authorize]
    [Area("Panel")]
    public class HomeController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;

        public HomeController(IHttpClientFactory clientFactory, ITokenService tokenService)
        {
            _client = clientFactory.CreateClient("GemSoftAppClient");
            _tokenService = tokenService;
        }
        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            if (!_tokenService.IsInAdminRole)
                return View();

            ViewBag.role = "admin";
            var response = await _client.GetFromJsonAsync<ResponseModel<List<OrderViewModel>>>("Orders/GetAll/");
            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);

                return View();
            }

            List<OrderViewModel> dailyOrders = response.data.Where(p => p.OrderDate.ToShortDateString() == DateTime.Now.ToShortDateString()).ToList();
            ViewBag.orderCount = dailyOrders.Where(p => p.Status != OrderStatus.Cancelled).Count();
            ViewBag.cancelledOrderCount = dailyOrders.Where(p => p.Status == OrderStatus.Cancelled).Count();
            ViewBag.totalPrice = dailyOrders.Where(p => p.Status != OrderStatus.Cancelled).Sum(p => p.TotalPrice);

            var products = await _client.GetFromJsonAsync<ResponseModel<List<ProductViewModel>>>("Products/GetAll/");
            var productSummary = Summary.GetProductOrderSummary(dailyOrders, products.data);

            ViewBag.productSummary = productSummary;
            return View(dailyOrders.Where(p => p.Status != OrderStatus.Cancelled).Take(5).ToList());
        }


        [HttpGet]
        public async Task<IActionResult> MyOrders()
        {
            var response = await _client.GetFromJsonAsync<ResponseModel<List<OrderViewModel>>>("Orders/GetOrdersWithDetailByUserId/" + _tokenService.GetUserId);
            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);

                return View();
            }
            List<OrderViewModel> orders = response.data;

            return View(orders);
        }
        [HttpGet]
        public async Task<IActionResult> Invoice(int orderId = 0)
        {
            ResponseModel<OrderViewModel>? response;
            if (orderId == 0)
                response = await _client.GetFromJsonAsync<ResponseModel<OrderViewModel>>("Orders/GetOrderWithDetailByUserId/" + _tokenService.GetUserId);
            else
                response = await _client.GetFromJsonAsync<ResponseModel<OrderViewModel>>("Orders/GetById/" + orderId);

            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);

                return View();
            }
            OrderViewModel order = response.data;
            return View(order);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id, OrderStatus status)
        {
            var response = await _client.GetFromJsonAsync<ResponseModel<OrderViewModel>>("Orders/GetById/" + id);
            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);

                return View();
            }
            UpdateOrderViewModel order = new()
            {
                Id = response.data.Id,
                Status = status
            };

            var updateResult = await _client.PutAsJsonAsync<UpdateOrderViewModel>("Orders/Update", order);
            var updateResponse = await updateResult.Content.ReadFromJsonAsync<ResponseModel<NoDataViewModel>>();

            if (updateResponse.error is not null)
            {
                foreach (var item in updateResponse.error.errors)
                    ModelState.AddModelError("", item);

                return View();
            }
            return RedirectToAction("Invoice", "Home", new { orderId = id, Area = "panel" });
        }
    }
}


