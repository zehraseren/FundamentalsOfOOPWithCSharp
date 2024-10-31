using FluentValidation;
using Agriculture.EntityLayer.Concrete;

namespace Agriculture.BusinessLayer.ValidationRules
{
    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(x => x.ImageTitle).NotEmpty().WithMessage("Görsel başlığı boş geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Görsel açıklama kısmını boş geçilemez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel URL yolu boş geçilemez");
            RuleFor(x => x.ImageTitle).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter girişi yapınız");
            RuleFor(x => x.ImageTitle).MinimumLength(8).WithMessage("Lütfen en az 8 karakter girişi yapınız");
            RuleFor(x => x.Description).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapınız");
            RuleFor(x => x.Description).MinimumLength(20).WithMessage("Lütfen en az 20 karakter girişi yapınız");
        }
    }
}
