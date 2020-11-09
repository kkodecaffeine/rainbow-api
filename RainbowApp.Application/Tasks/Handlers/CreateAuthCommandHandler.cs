using MediatR;
using System.Threading;
using System.Threading.Tasks;
using RainbowApp.Application.Interfaces;
using RainbowApp.Application.Tasks.Commands;
using RainbowApp.Core.Entities;

namespace RainbowApp.Application.Tasks.Handlers
{
    public class CreateAuthCommandHandler : IRequestHandler<CreateAuthCommand, AuthenticateResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAuthCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AuthenticateResponse> Handle(CreateAuthCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Users.Authenticate(request.MailAddr, request.Password);
            return result;
        }
    }
}
