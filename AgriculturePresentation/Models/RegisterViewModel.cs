using System.ComponentModel.DataAnnotations;

namespace Agriculture.Presentation.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz")]
        public string username { get; set; }

        [Required(ErrorMessage = "Lütfen mail adresinizi giriniz")]
        public string mail { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string password { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz")]
        [Compare("password", ErrorMessage = "Şifreler uyumlu değil")]
        public string passwordConfirm { get; set; }
    }
}
