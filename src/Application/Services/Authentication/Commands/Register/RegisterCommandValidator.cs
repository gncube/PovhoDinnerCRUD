using FluentValidation;

namespace Application.Services.Authentication.Commands.Register;
public class RegisterCommandValidator : AbstractValidator<TRequest>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MinimumLength(3);
        RuleFor(x => x.LastName)
            .NotEmpty()
            .MinimumLength(3);
        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6);
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
}
