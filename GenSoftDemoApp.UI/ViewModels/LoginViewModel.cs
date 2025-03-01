using System.ComponentModel.DataAnnotations;

namespace GemSoftDemoApp.UI.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Kullanıcı Adı Boş Bırakılamaz")]
        [Display(Name = "Kullanıcı Adı:")]
        public string Username { get; set; } = null!;
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre Boş Bırakılamaz")]
        [Display(Name = "Şifre :")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karekter olabilir")]
        public string Password { get; set; } = null!;


    }
}
