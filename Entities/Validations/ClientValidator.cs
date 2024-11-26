using Entities.Model;
using FluentValidation;

namespace Entities.Validations
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(x => x.Cpf).NotNull().NotEmpty().MaximumLength(11);
            RuleFor(x => x.Email).NotNull().NotEmpty().MaximumLength(200).EmailAddress();
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().MaximumLength(11);
            RuleFor(x => x.Cep).NotNull().NotEmpty().MaximumLength(8);
            RuleFor(x => x.Address).NotNull().NotEmpty().MaximumLength(300);
            RuleFor(x => x.City).NotNull().NotEmpty().MaximumLength(300);
            RuleFor(x => x.IdUser).NotNull();
        }
    }
}
