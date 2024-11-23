using Entities.Model;
using FluentValidation;

namespace Entities.Validations;

/// <summary>
/// Classe de validação dos usuários
/// </summary>
public class UserValidator : AbstractValidator<User>
{
    /// <summary>
    /// Construtor da classe de validação dos usuários
    /// </summary>
    public UserValidator()
    {
        RuleFor(x => x.USER_NAME).NotNull().NotEmpty().MaximumLength(200);
        RuleFor(x => x.USER_EMAIL).NotNull().NotEmpty().MaximumLength(200).EmailAddress();
        RuleFor(x => x.USER_PASSWORD).NotNull().NotEmpty().MaximumLength(500);
    }
}
