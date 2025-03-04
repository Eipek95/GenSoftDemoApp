using System.ComponentModel.DataAnnotations;

namespace GenSoftDemoApp.UI.ViewModels.CategoryViewModels
{
    public class CreateCategoryViewModel
    {
        [Required(ErrorMessage = "Başlık Boş Bırakılamaz")]
        [MaxLength(100, ErrorMessage = "Başlık en fazla 100 karekter olabilir")]
        public string Title { get; set; } = null!;
    }
}
