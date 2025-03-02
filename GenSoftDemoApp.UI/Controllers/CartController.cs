using GenSoftDemoApp.UI.Models;
using GenSoftDemoApp.UI.Services.SessionServices;
using GenSoftDemoApp.UI.Services.TokenServices;
using GenSoftDemoApp.UI.ViewModels.CartViewModels;
using GenSoftDemoApp.UI.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;
        private readonly CartService _cartService;

        public CartController(IHttpClientFactory clientFactory, ITokenService tokenService, CartService cartService)
        {
            _client = clientFactory.CreateClient("GemSoftAppClient");
            _tokenService = tokenService;
            _cartService = cartService;
        }
        [HttpGet]
        public async Task<IActionResult> AddCart(int productId, int quantity, string? returnUrl)
        {

            if (_tokenService.GetUserId == 0)
                return RedirectToAction("Login", "Auth");


            var response = await _client.GetFromJsonAsync<ResponseModel<ProductViewModel>>("Products/GetById/" + productId);

            if (response.error is not null)
            {
                foreach (var item in response.error.errors)
                    ModelState.AddModelError("", item);

                return View();
            }
            var product = response.data;
            var cart = new CartItemViewModel
            {
                CategoryId = product.CategoryId,
                ProductId = product.Id,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Quantity = quantity,
                Title = product.Title,
                UserId = _tokenService.GetUserId
            };

            _cartService.AddToCart(cart);
            return Redirect($"{returnUrl}");
        }


        [HttpGet]
        public IActionResult MyCart()
        {
            List<CartItemViewModel> cart = _cartService.GetCart();
            ViewBag.total = _cartService.GetTotal();
            return View(cart);
        }
        [HttpGet]
        public IActionResult RemoveFromCart(int productId)
        {

            if (_tokenService.GetUserId == 0)
                return RedirectToAction("Login", "Auth");

            _cartService.RemoveFromCart(productId);
            return RedirectToAction("MyCart");
        }
        [HttpGet]
        public IActionResult ClearCart()
        {
            _cartService.ClearCart();
            return RedirectToAction("MyCart");
        }
    }
}