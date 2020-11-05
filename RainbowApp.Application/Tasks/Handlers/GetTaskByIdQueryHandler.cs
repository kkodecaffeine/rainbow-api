﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RainbowApp.Application.Interfaces;
using RainbowApp.Application.Tasks.Dto;
using RainbowApp.Application.Tasks.Queries;

namespace RainbowApp.Application.Tasks.Handlers
{
    //public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskDto>
    //{
    //    private readonly IUnitOfWork _unitOfWork;
    //    private readonly IMapper _mapper;

    //    public GetTaskByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    //    {
    //        _unitOfWork = unitOfWork;
    //        _mapper = mapper;
    //    }
    //    public async Task<TaskDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    //    {
    //        var result = await _unitOfWork.Tasks.Get(request.Id);
    //        return _mapper.Map<TaskDto>(result);
    //    }
    //}
}
