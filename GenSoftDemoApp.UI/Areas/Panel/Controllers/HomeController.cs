using GenSoftDemoApp.UI.Models;
using GenSoftDemoApp.UI.Services.TokenServices;
using GenSoftDemoApp.UI.ViewModels.OrderViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.UI.Areas.Panel.Controllers
{
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

        public IActionResult Dashboard()
        {
            return View();
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
    }
}
