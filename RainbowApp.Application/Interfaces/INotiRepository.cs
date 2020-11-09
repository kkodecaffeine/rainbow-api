using System.Collections.Generic;
using System.Threading.Tasks;
using RainbowApp.Core.Entities;

namespace RainbowApp.Application.Interfaces
{
    public interface INotiRepository
    {
        Task<IEnumerable<Notification>> GetNotifications(int userId, bool bIsGetOnlyUnread);
    }
}