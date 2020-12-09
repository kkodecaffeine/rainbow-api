using Microsoft.Extensions.DependencyInjection;
using RainbowApp.Application.Interfaces;
using RainbowApp.Application.Model;
using RainbowApp.Infrastructure.Filters;
using RainbowApp.Infrastructure.Repositories;

namespace RainbowApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)));

            services.AddTransient<IRainbowContext, RainbowContext>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<INotiRepository, NotiRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        } 
    }
}
