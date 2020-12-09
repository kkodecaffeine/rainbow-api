using MediatR;
using RainbowApp.Core.Entities;

namespace RainbowApp.Application.Tasks.Commands
{
    public class CreateResetPasswordCommand : IRequest<int>
    {
        public ResetPasswordRequest ResetPasswordRequest { get; set; }
        public int UserId { get; set; }
    }
}
