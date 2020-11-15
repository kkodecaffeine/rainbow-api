using RainbowApp.Application.Model;

namespace RainbowApp.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IRainbowContext Context { get; }
        IUserRepository Users { get; }
        ITaskRepository Tasks { get; }
        INotiRepository Notis { get; }
    }
}