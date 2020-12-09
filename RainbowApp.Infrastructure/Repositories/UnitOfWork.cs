using RainbowApp.Application.Interfaces;
using RainbowApp.Application.Model;

namespace RainbowApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IRainbowContext context
            , IAccountRepository userRepository
            , ITaskRepository taskRepository
            , INotiRepository notiRepository)
        {
            Context = context;
            Users = userRepository;
            Tasks = taskRepository;
            Notis = notiRepository;
        }

        public IRainbowContext Context { get; }
        public IAccountRepository Users { get; }
        public ITaskRepository Tasks { get; }
        public INotiRepository Notis { get; }
    }
}
