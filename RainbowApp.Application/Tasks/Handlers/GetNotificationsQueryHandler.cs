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
    public class GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, List<TblNotification>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetNotificationsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<TblNotification>> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Notis.GetNotifications(request.UserId, false);
            return _mapper.Map<List<TblNotification>>(result.ToList());
        }
    }
}
