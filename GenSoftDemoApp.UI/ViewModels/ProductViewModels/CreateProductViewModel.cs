using System.ComponentModel.DataAnnotations;

namespace GenSoftDemoApp.UI.ViewModels.ProductViewModels
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "Başlık Boş Bırakılamaz")]
        [MaxLength(256, ErrorMessage = "Başlık en fazla 256 karekter olabilir")]
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
