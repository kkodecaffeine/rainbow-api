using AutoMapper;
using RainbowApp.Application.Tasks.Commands;
using RainbowApp.Application.Tasks.Dto;
using RainbowApp.Core.Entities;

namespace RainbowApp.Application.Tasks.MappingProfiles
{
    public class TaskMappingProfile: Profile
    {
        public TaskMappingProfile()
        {
            //CreateMap<CreateTaskCommand, Task>();
            //CreateMap<UpdateTaskCommand, Task>();
            CreateMap<ServiceProvider, ServiceProviderDto>();
            CreateMap<Notification, NotificationDto>();
        }
    }
}
