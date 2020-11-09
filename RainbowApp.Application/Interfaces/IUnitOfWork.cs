namespace RainbowApp.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        ITaskRepository Tasks { get; }
        INotiRepository Notis { get; }
    }
}