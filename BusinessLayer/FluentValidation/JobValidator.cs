using FluentValidation;
using EntityLayer.Concrete;

namespace BusinessLayer.FluentValidation
{
    public class JobValidator : AbstractValidator<Job>
    {
        public JobValidator()
        {
            RuleFor(x => x.JobName).NotEmpty().WithMessage("Ürün adını boş geçilemez");
            RuleFor(x => x.JobName).MinimumLength(3).WithMessage("Ürün adını en az 3 karakter olmalıdır");
        }
    }
}
