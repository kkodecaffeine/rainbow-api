using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RainbowApp.Application.Interfaces;
using RainbowApp.Application.Model;
using RainbowApp.Application.Tasks.Queries;

namespace RainbowApp.Application.Tasks.Handlers
{
    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, List<TblAccount>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAccountsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<TblAccount>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Users.GetUser(request.Email, request.Password);
            return _mapper.Map<List<TblAccount>>(new[] { result });
        }
    }
}
