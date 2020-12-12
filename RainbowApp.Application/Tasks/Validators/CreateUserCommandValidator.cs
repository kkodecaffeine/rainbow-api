using FluentValidation;
using RainbowApp.Application.Interfaces;
using RainbowApp.Application.Tasks.Commands;

namespace RainbowApp.Application.Tasks.Validators
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator(IAccountRepository accountRepository)
        {
            RuleFor(t => t.RegisterRequest.Email).NotEmpty();
            RuleFor(x => x.RegisterRequest.Email).Must(x => accountRepository.GetUser(x) != null).WithMessage("A user with this email already exists.");
            RuleFor(t => t.RegisterRequest.Password).NotEmpty();
            RuleFor(t => t.RegisterRequest.ConfirmPassword).NotEmpty();
        }
    }
}
