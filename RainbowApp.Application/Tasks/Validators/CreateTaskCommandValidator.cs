using FluentValidation;
using RainbowApp.Application.Tasks.Commands;

namespace RainbowApp.Application.Tasks.Validators
{
    public class CreateTaskCommandValidator: AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.Description).NotEmpty();
            RuleFor(t => t.Status).NotNull();
            RuleFor(t => t.DueDate).NotNull();
        }
    }
}
