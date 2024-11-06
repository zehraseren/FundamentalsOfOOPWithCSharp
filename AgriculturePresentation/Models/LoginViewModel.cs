using System.ComponentModel.DataAnnotations;

namespace Agriculture.Presentation.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz")]
        public string username { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string password { get; set; }
    }
}
