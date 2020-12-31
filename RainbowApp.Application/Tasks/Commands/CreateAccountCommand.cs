using MediatR;
using RainbowApp.Core.Entities;

namespace RainbowApp.Application.Tasks.Commands
{
    public class CreateAccountCommand : IRequest<ApiResponse>
    {
        public RegisterRequest RegisterRequest {get; set;}
        public string Origin { get; set; }
    }
}
