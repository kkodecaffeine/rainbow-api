﻿using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using RainbowApp.Application.Interfaces;
using RainbowApp.Application.Tasks.Commands;

namespace RainbowApp.Application.Tasks.Handlers
{
    //public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
    //{
    //    private readonly IUnitOfWork _unitOfWork;
    //    private readonly IMapper _mapper;

    //    public CreateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    //    {
    //        _unitOfWork = unitOfWork;
    //        _mapper = mapper;
    //    }
    //    public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    //    {
    //        var result = await _unitOfWork.Tasks.Add(_mapper.Map<TaskManagementApp.Core.Entities.Task>(request));
    //        return result;
    //    }
    //}
}
