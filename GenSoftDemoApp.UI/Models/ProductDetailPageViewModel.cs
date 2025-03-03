using GenSoftDemoApp.UI.ViewModels.ProductViewModels;

namespace GenSoftDemoApp.UI.Models
{
    public class ProductDetailPageViewModel
    {
        public ProductViewModel Product { get; set; }
        public List<ProductDetailCommentViewModel> Comments { get; set; }
    }

}
