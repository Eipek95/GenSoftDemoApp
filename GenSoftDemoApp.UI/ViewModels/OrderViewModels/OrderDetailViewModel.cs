using GenSoftDemoApp.UI.ViewModels.ProductViewModels;

namespace GenSoftDemoApp.UI.ViewModels.OrderViewModels
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public ProductViewModel? Product { get; set; }
    }
}
