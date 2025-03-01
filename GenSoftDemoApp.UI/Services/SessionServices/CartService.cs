using GenSoftDemoApp.UI.Extensions;
using GenSoftDemoApp.UI.ViewModels.CartViewModels;

namespace GenSoftDemoApp.UI.Services.SessionServices
{
    public class CartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string CartSessionKey = "cart";

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ISession Session => _httpContextAccessor.HttpContext.Session;

        public void SaveCart(List<CartItemViewModel> cart)
        {
            Session.SetObjectAsJson(CartSessionKey, cart);
        }

        public List<CartItemViewModel> GetCart()
        {
            var cart = Session.GetObjectFromJson<List<CartItemViewModel>>(CartSessionKey);
            return cart ?? new List<CartItemViewModel>();
        }

        public decimal GetTotal()
        {
            var cart = GetCart();
            return cart.Sum(item => item.Price * item.Quantity);
        }

        public int GetCartItemCount()
        {
            var cart = GetCart();
            return cart.Sum(item => item.Quantity);
        }

        public void AddToCart(CartItemViewModel newItem)
        {
            var cart = GetCart();

            var existingItem = cart.FirstOrDefault(x => x.ProductId == newItem.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += newItem.Quantity;
            }
            else
            {
                cart.Add(newItem);
            }

            SaveCart(cart);
        }

        public void RemoveFromCart(int productId)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                cart.Remove(item);
            }
            SaveCart(cart);
        }
        public void ClearCart()
        {
            Session.Remove(CartSessionKey);
        }
    }

}
