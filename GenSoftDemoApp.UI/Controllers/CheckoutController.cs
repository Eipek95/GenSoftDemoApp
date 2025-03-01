using GenSoftDemoApp.UI.Services.SessionServices;
using GenSoftDemoApp.UI.Services.TokenServices;
using GenSoftDemoApp.UI.ViewModels.CartViewModels;
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
        public IActionResult Index(int product = 0)
        {

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
                SuccessUrl = "https://localhost:7296/CheckOut/Success",
                CancelUrl = "https://localhost:7296/Error"

            };

            var service = new SessionService();
            Session session = service.Create(options);
            HttpContext.Session.SetString("SessionId", session.Id);
            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
            return View();
        }
    }
}
//4242424242424242
//4000000000000002