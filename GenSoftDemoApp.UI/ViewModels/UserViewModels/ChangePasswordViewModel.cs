using System.ComponentModel.DataAnnotations;

namespace GenSoftDemoApp.UI.ViewModels.UserViewModels
{
    public class ChangePasswordViewModel
    {
        public string? Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre Boş Bırakılamaz")]
        [Display(Name = "Şifre :")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karekter olabilir")]
        public string CurrentPassword { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre Boş Bırakılamaz")]
        [Display(Name = "Yeni Şifre :")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karekter olabilir")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword), ErrorMessage = "Şifre Aynı Değildir")]
        [Required(ErrorMessage = "Şifre Tekrar Boş Bırakılamaz")]
        [Display(Name = "Şifre Tekrar:")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karekter olabilir")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
