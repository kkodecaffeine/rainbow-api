using MediatR;
using RainbowApp.Application.Model;
using System.Collections.Generic;

namespace RainbowApp.Application.Tasks.Queries
{
    public class GetAllTasksQuery: IRequest<List<TblServiceProvider>>
    {
    }
}
