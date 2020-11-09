using RainbowApp.Application.Interfaces;

namespace RainbowApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUserRepository userRepository
            , ITaskRepository taskRepository
            , INotiRepository notiRepository)
        {
            Users = userRepository;
            Tasks = taskRepository;
            Notis = notiRepository;
        }

        public IUserRepository Users { get; }
        public ITaskRepository Tasks { get; }
        public INotiRepository Notis { get; }
    }
}
