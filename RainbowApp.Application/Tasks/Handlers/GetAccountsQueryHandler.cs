using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RainbowApp.Application.Interfaces;
using RainbowApp.Application.Tasks.Queries;
using RainbowApp.Core.Entities;

namespace RainbowApp.Application.Tasks.Handlers
{
    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, ApiResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAccountsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<ApiResponse> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            var apiResult = new ApiResponse();
            var result = await _unitOfWork.Accounts.GetUser(request.Email, request.Password);

            if (result == null)
            {
                apiResult.SetFail(HttpStatusCode.NotFound, 1001, "This account does not exist");
                return _mapper.Map<ApiResponse>(apiResult);
            }

            apiResult.SetSuccessData(result);

            return _mapper.Map<ApiResponse>(apiResult);
        }
    }
}
