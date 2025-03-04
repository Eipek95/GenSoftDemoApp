using GenSoftDemoApp.UI.Models;
using GenSoftDemoApp.UI.Services.TokenServices;
using GenSoftDemoApp.UI.ViewModels.OrderViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GenSoftDemoApp.UI.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize(Roles = "Admin")]
    public class AdminOrderController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;

        public AdminOrderController(IHttpClientFactory clientFactory, ITokenService tokenService)
        {
            _client = clientFactory.CreateClient("GemSoftAppClient");
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "Orders/GetAll/");

            var httpResponse = await _client.SendAsync(request);

            if (httpResponse.StatusCode == HttpStatusCode.NotFound)
                return View(new List<OrderViewModel>());

            httpResponse.EnsureSuccessStatusCode();
            var response = await httpResponse.Content.ReadFromJsonAsync<ResponseModel<List<OrderViewModel>>>();

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
        public async Task<IActionResult> Update(int orderId)
        {
            var response = await _client.GetFromJsonAsync<ResponseModel<OrderViewModel>>("Orders/GetById/" + orderId);
            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);

                return View();
            }
            UpdateOrderViewModel order = new()
            {
                Id = response.data.Id,
                Status = response.data.Status,
            };
            return View(order);

        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateOrderViewModel model)
        {

            var updateResult = await _client.PutAsJsonAsync<UpdateOrderViewModel>("Orders/Update", model);
            var updateResponse = await updateResult.Content.ReadFromJsonAsync<ResponseModel<NoDataViewModel>>();

            if (updateResponse.error is not null)
            {
                foreach (var item in updateResponse.error.errors)
                    ModelState.AddModelError("", item);

                return View();
            }
            return RedirectToAction("Index", "AdminOrder", new { Area = "panel" });
        }

    }
}
