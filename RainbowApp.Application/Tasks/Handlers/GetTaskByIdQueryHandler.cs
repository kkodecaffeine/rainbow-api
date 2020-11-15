using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using RainbowApp.Application.Interfaces;
using RainbowApp.Application.Tasks.Queries;
using RainbowApp.Application.Model;

namespace RainbowApp.Application.Tasks.Handlers
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetServiceProviderByMgtNoQuery, TblServiceProvider>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTaskByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<TblServiceProvider> Handle(GetServiceProviderByMgtNoQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Tasks.Get(request.MgtNo);
            return _mapper.Map<TblServiceProvider>(result);
        }
    }
}
