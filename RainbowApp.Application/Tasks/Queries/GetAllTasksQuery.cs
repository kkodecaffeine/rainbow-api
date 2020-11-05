using MediatR;
using System.Collections.Generic;
using RainbowApp.Application.Tasks.Dto;

namespace RainbowApp.Application.Tasks.Queries
{
    public class GetAllTasksQuery: IRequest<List<ServiceProviderDto>>
    {
    }
}
