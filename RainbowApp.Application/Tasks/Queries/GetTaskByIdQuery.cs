using MediatR;
using RainbowApp.Application.Tasks.Dto;

namespace RainbowApp.Application.Tasks.Queries
{
    public class GetTaskByIdQuery: IRequest<TaskDto>
    {
        public int Id { get; set; }
    }
}
