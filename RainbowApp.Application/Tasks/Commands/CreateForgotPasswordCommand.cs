using MediatR;
using RainbowApp.Core.Entities;

namespace RainbowApp.Application.Tasks.Commands
{
    public class CreateForgotPasswordCommand : IRequest<int>
    {
        public ForgotPasswordRequest ForgotPasswordRequest { get; set; }
        public string Origin { get; set; }
    }
}
