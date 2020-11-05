using MediatR;
using System;
using RainbowApp.Core.Enums;

namespace RainbowApp.Application.Tasks.Commands
{
    public class CreateTaskCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime DueDate { get; set; }
    }
}
