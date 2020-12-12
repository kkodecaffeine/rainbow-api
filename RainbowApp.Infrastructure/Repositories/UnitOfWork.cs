using RainbowApp.Application.Interfaces;
using RainbowApp.Application.Model;

namespace RainbowApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IRainbowContext context
            , IAccountRepository accountRepository
            , ITaskRepository taskRepository
            , INotiRepository notiRepository)
        {
            Context = context;
            Accounts = accountRepository;
            Tasks = taskRepository;
            Notis = notiRepository;
        }

        public IRainbowContext Context { get; }
        public IAccountRepository Accounts { get; }
        public ITaskRepository Tasks { get; }
        public INotiRepository Notis { get; }
    }
}
