using FluentValidation;
using Agriculture.EntityLayer.Concrete;

namespace Agriculture.BusinessLayer.ValidationRules
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x => x.PersonName).NotEmpty().WithMessage("Takım arkadaşı ismi boş geçilemez");
            RuleFor(x => x.PersonName).MaximumLength(50).WithMessage("Lütfen 50 karakterden daha az veri girişi yapınız");
            RuleFor(x => x.PersonName).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız");
            RuleFor(x => x.PersonTitle).NotEmpty().WithMessage("Görev kısmı boş geçilemez");
            RuleFor(x => x.PersonTitle).MaximumLength(50).WithMessage("Lütfen 50 karakterden daha az veri girişi yapınız");
            RuleFor(x => x.PersonTitle).MinimumLength(3).WithMessage("Lütfen en az 5 karakter veri girişi yapınız");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Görsel yolu kısmı boş geçilemez");
        }
    }
}
