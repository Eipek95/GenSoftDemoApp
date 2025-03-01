using GemSoftDemoApp.UI.ViewModels.BrandViewModels;
using GemSoftDemoApp.UI.ViewModels.CategoryViewModels;

namespace GemSoftDemoApp.UI.ViewModels.ProductViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int BrandId { get; set; }
        public BrandViewModel? Brand { get; set; }
        public int CategoryId { get; set; }
        public CategoryViewModel? Category { get; set; }
    }
}
