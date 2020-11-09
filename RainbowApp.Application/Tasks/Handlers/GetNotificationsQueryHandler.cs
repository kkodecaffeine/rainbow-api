using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RainbowApp.Application.Interfaces;
using RainbowApp.Application.Tasks.Dto;
using RainbowApp.Application.Tasks.Queries;

namespace RainbowApp.Application.Tasks.Handlers
{
    public class GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, List<NotificationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetNotificationsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<NotificationDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Tasks.GetAll();
            return _mapper.Map<List<NotificationDto>>(result.ToList());
        }
    }
}
