using RainbowApp.Application.Model;

namespace RainbowApp.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IRainbowContext Context { get; }
        IAccountRepository Users { get; }
        ITaskRepository Tasks { get; }
        INotiRepository Notis { get; }
    }
}