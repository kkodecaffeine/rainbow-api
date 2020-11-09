namespace RainbowApp.Application.Interfaces
{
    public interface IUnitOfWork
    {
        ITaskRepository Tasks { get; }
        INotiRepository Notis { get; }
    }
}