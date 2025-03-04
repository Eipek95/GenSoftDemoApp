using System.ComponentModel.DataAnnotations;

namespace GenSoftDemoApp.UI.ViewModels.CategoryViewModels
{
    public class UpdateCategoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Başlık Boş Bırakılamaz")]
        [MaxLength(100, ErrorMessage = "Başlık en fazla 100 karekter olabilir")]
        public string Title { get; set; } = null!;
    }
}
