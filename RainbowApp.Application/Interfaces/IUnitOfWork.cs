using RainbowApp.Application.Model;

namespace RainbowApp.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IRainbowContext Context { get; }
        IAccountRepository Accounts { get; }
        ITaskRepository Tasks { get; }
        INotiRepository Notis { get; }
    }
}