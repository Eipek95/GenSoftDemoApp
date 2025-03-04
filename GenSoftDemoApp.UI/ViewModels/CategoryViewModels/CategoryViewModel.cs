using GenSoftDemoApp.UI.ViewModels.ProductViewModels;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GenSoftDemoApp.UI.ViewModels.CategoryViewModels
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
