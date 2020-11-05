using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RainbowApp.Application.Interfaces;
using RainbowApp.Application.Tasks.Dto;
using RainbowApp.Application.Tasks.Queries;

namespace RainbowApp.Application.Tasks.Handlers
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, List<ServiceProviderDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllTasksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ServiceProviderDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _unitOfWork.Tasks.GetAll();
                return _mapper.Map<List<ServiceProviderDto>>(result.ToList());
            }
            catch (System.Exception ex)
            {

            }
            return null;
        }
    }
}
