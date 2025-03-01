using System.ComponentModel.DataAnnotations;

namespace GenSoftDemoApp.UI.ViewModels
{
    public class RegisterViewModel
    {
      
        [Required(ErrorMessage = "Kullanıcı Adı Boş Bırakılamaz")]
        [Display(Name = "Kullanıcı Adı :")]
        public string UserName { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Email Formatı Yanlış")]
        [Required(ErrorMessage = "Email Boş Bırakılamaz")]
        [Display(Name = "Email :")]
        public string Email { get; set; } = null!;


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre Boş Bırakılamaz")]
        [Display(Name = "Şifre :")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karekter olabilir")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Şifre Aynı Değildir")]
        [Required(ErrorMessage = "Şifre Tekrar Boş Bırakılamaz")]
        [Display(Name = "Şifre Tekrar:")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karekter olabilir")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
