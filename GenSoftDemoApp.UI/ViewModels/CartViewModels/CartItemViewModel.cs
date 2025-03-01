namespace GemSoftDemoApp.UI.ViewModels.CartViewModels
{
    public class CartItemViewModel
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }

        public decimal Total
        {
            get
            {
                return Quantity * Price;
            }
        }
    }
}
