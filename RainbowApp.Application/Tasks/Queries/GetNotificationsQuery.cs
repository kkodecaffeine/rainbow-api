using System.Collections.Generic;
using MediatR;
using RainbowApp.Application.Model;

namespace RainbowApp.Application.Tasks.Queries
{
    public class GetNotificationsQuery : IRequest<List<TblNotification>>
    {
        public int UserId { get; set; }
        public bool IsGetOnlyUnread { get; set; }
    }
}
