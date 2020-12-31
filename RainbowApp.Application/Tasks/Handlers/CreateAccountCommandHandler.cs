using MediatR;
using System.Threading;
using System.Threading.Tasks;
using RainbowApp.Application.Interfaces;
using RainbowApp.Application.Tasks.Commands;
using RainbowApp.Core.Entities;
using AutoMapper;
using System.Net;

namespace RainbowApp.Application.Tasks.Handlers
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, ApiResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAccountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var apiResult = new ApiResponse();
            var result = await _unitOfWork.Accounts.AddUser(_mapper.Map<RegisterRequest>(request.RegisterRequest), request.Origin);
            
            if (result == 0)
            {
                apiResult.SetFail(HttpStatusCode.BadRequest, 1002, "This account exist");
                return _mapper.Map<ApiResponse>(apiResult);
            }

            apiResult.SetSuccessData(result);

            return apiResult;
        }

        public async Task<int> Handle(CreateResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Accounts.ResetPassword(_mapper.Map<ResetPasswordRequest>(request.ResetPasswordRequest), request.UserId);
            return result;
        }
    }
}
