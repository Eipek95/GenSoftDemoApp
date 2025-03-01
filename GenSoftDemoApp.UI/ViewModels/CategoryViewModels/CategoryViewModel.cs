using GemSoftDemoApp.UI.ViewModels.ProductViewModels;
using System.Text.Json.Serialization;

namespace GemSoftDemoApp.UI.ViewModels.CategoryViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public List<ProductViewModel>? Products { get; set; }

        [JsonIgnore]
        public int? ProductCount { get; set; }
    }
}
