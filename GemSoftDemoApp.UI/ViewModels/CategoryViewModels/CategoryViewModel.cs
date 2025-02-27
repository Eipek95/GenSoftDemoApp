using GemSoftDemoApp.UI.ViewModels.ProductViewModels;

namespace GemSoftDemoApp.UI.ViewModels.CategoryViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public List<ProductViewModel>? Products { get; set; }
    }
}
