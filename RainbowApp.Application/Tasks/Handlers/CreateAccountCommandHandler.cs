using MediatR;
using System.Threading;
using System.Threading.Tasks;
using RainbowApp.Application.Interfaces;
using RainbowApp.Application.Tasks.Commands;
using RainbowApp.Core.Entities;
using AutoMapper;

namespace RainbowApp.Application.Tasks.Handlers
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAccountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Accounts.AddUser(_mapper.Map<RegisterRequest>(request.RegisterRequest), request.Origin);
            return result;
        }

        public async Task<int> Handle(CreateResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Accounts.ResetPassword(_mapper.Map<ResetPasswordRequest>(request.ResetPasswordRequest), request.UserId);
            return result;
        }
    }
}
