namespace GenSoftDemoApp.UI.ViewModels.ProductViewModels
{
    public class CreateProductViewModel
    {
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
