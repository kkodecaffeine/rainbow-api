using RainbowApp.Application.Interfaces;

namespace RainbowApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ITaskRepository taskRepository
            ,INotiRepository notiRepository)
        {
            Tasks = taskRepository;
            Notis = notiRepository;
        }

        //public UnitOfWork(INotiRepository notiRepository)
        //{
        //    Notis = notiRepository;
        //}

        public ITaskRepository Tasks { get; }
        public INotiRepository Notis { get; }
    }
}
