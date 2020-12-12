using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RainbowApp.Application.Interfaces;
using RainbowApp.Application.Tasks.Queries;
using RainbowApp.Core.Entities;

namespace RainbowApp.Application.Tasks.Handlers
{
    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, List<Account>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAccountsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<Account>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Accounts.GetUser(request.Email, request.Password);
            return _mapper.Map<List<Account>>(new [] { result });
        }
    }
}
