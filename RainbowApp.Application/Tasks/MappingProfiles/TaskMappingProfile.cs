using AutoMapper;
using RainbowApp.Application.Model;
using RainbowApp.Core.Entities;

namespace RainbowApp.Application.Tasks.MappingProfiles
{
    public class TaskMappingProfile: Profile
    {
        public TaskMappingProfile()
        {
            //CreateMap<CreateTaskCommand, Task>();
            //CreateMap<UpdateTaskCommand, Task>();
            CreateMap<ServiceProvider, TblServiceProvider>();
            CreateMap<Notification, TblNotification>();
        }
    }
}
