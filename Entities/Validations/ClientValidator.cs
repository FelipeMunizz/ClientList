using Entities.Model;
using FluentValidation;

namespace Entities.Validations
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(x => x.NAME).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(x => x.CPF).NotNull().NotEmpty().MaximumLength(11);
            RuleFor(x => x.EMAIL).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(x => x.PHONE_NUMBER).NotNull().NotEmpty().MaximumLength(11);
            RuleFor(x => x.CEP).NotNull().NotEmpty().MaximumLength(8);
            RuleFor(x => x.ADDRESS).NotNull().NotEmpty().MaximumLength(300);
            RuleFor(x => x.CITY).NotNull().NotEmpty().MaximumLength(300);
        }
    }
}
