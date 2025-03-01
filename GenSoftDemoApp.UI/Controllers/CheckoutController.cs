using GenSoftDemoApp.UI.Models;
using GenSoftDemoApp.UI.Services.SessionServices;
using GenSoftDemoApp.UI.Services.TokenServices;
using GenSoftDemoApp.UI.ViewModels;
using GenSoftDemoApp.UI.ViewModels.CartViewModels;
using GenSoftDemoApp.UI.ViewModels.OrderViewModels;
using GenSoftDemoApp.UI.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace GenSoftDemoApp.UI.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;
        private readonly CartService _cartService;

        public CheckoutController(IHttpClientFactory clientFactory, ITokenService tokenService, CartService cartService)
        {
            _client = clientFactory.CreateClient("GemSoftAppClient");
            _tokenService = tokenService;
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<CartItemViewModel> myCart = _cartService.GetCart();
            ViewBag.total = _cartService.GetTotal();
            return View(myCart);
        }
        [HttpPost]
        public IActionResult Index(CreateOrderViewModel? model)
        {
            string successUrl = "https://localhost:7213" + Url.Action("Success", "Checkout", model);
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "try",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Market Ödemesi"
                            },
                            UnitAmount = (long)(_cartService.GetTotal() * 100)  // 100 ile çarparak kuruşa çevir,
                        },
                        Quantity = 1,
                    }
                },
                Mode = "payment",
                SuccessUrl = successUrl,
                CancelUrl = "https://localhost:7213/Error"

            };

            var service = new SessionService();
            Session session = service.Create(options);
            HttpContext.Session.SetString("SessionId", session.Id);
            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Success(CreateOrderViewModel? model)
        {

            var cart = _cartService.GetCart();
            if (cart.Count > 0)
            {
                var order = new CreateOrderViewModel
                {
                    IpAddress = HttpContext.Connection.RemoteIpAddress.ToString(),
                    OrderDetails = cart.Select(x => new CreateOrderDetailViewModel
                    {
                        ProductId = x.ProductId,
                        Price = x.Price,
                        Quantity= x.Quantity,
                    }).ToList(),
                    Address=model.Address,
                    City = model.City,
                    CompanyName = model.CompanyName,
                    FullName = model.FullName,
                    Mail=model.Mail,
                    Notes = model.Notes,
                    PhoneNumber = model.PhoneNumber,
                    Province = model.Province,
                    UserId=_tokenService.GetUserId,
                    TotalPrice = _cartService.GetTotal()
                };

                var result = await _client.PostAsJsonAsync("Orders/Create", order);
                var response = await result.Content.ReadFromJsonAsync<ResponseModel<CreateOrderViewModel>>();

                if (response.error is not null)
                {
                    foreach (var item in response.error.errors)
                        ModelState.AddModelError("", item);

                    return View();
                }

                HttpContext.Session.Clear();
            }
            var response2 = await _client.GetFromJsonAsync<ResponseModel<OrderViewModel>>("Orders/GetOrderWithDetailByUserId/" + _tokenService.GetUserId);
            return View(response2.data);
        }
    }
}
//4242424242424242
//4000000000000002