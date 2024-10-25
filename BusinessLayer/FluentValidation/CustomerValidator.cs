using FluentValidation;
using EntityLayer.Concrete;

namespace BusinessLayer.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Müşteri adını boş geçilemez");
            RuleFor(x => x.CustomerCity).NotEmpty().WithMessage("Şehir bilgisini boş geçilemez");
            RuleFor(x => x.CustomerName).MinimumLength(3).WithMessage("Müşteri adını en az 3 karakter olmalıdır");
            RuleFor(x => x.CustomerCity).MinimumLength(3).WithMessage("Şehir bilgisi en az 3 karakter olmalıdır");
        }
    }
}
