using GenSoftDemoApp.UI.ViewModels.CategoryViewModels;

namespace GenSoftDemoApp.UI.ViewModels.ProductViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public CategoryViewModel? Category { get; set; }
    }
}
