using System.ComponentModel.DataAnnotations;

namespace Agriculture.Presentation.Models
{
    public class AddServiceViewModel
    {
        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "Başlık boş geçilemez")]
        public string Title { get; set; }

        [Display(Name = "Görsel")]
        [Required(ErrorMessage = "Görsel değeri boş geçilemez")]
        public string Image { get; set; }

        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "Açıklama boş geçilemez")]
        public string Description { get; set; }
    }
}
