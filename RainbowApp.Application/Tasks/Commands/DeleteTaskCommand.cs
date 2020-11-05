using MediatR;

namespace RainbowApp.Application.Tasks.Commands
{
    public class DeleteTaskCommand: IRequest<int>
    {
        public int Id { get; set; }
    }
}
