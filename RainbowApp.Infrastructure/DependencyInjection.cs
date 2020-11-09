using Microsoft.Extensions.DependencyInjection;
using RainbowApp.Application.Interfaces;
using RainbowApp.Infrastructure.Repositories;

namespace RainbowApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<INotiRepository, NotiRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        } 
    }
}
