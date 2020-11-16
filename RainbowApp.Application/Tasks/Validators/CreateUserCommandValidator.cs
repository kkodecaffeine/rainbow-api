using FluentValidation;
using RainbowApp.Application.Interfaces;
using RainbowApp.Application.Tasks.Commands;

namespace RainbowApp.Application.Tasks.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator(IUserRepository userRepository)
        {
            RuleFor(t => t.RegisterRequest.MailAddr).NotEmpty();
            RuleFor(x => x.RegisterRequest.MailAddr).Must(x => userRepository.GetUser(x) == null).WithMessage("A user with this mailAddr already exists.");
            RuleFor(t => t.RegisterRequest.Password).NotEmpty();
            RuleFor(t => t.RegisterRequest.ConfirmPassword).NotEmpty();
        }
    }
}
