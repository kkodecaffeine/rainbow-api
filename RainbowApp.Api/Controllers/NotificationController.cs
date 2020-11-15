using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RainbowApp.Application.Model;
using RainbowApp.Application.Tasks.Queries;

namespace RainbowApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<TblNotification>>> GetNotifications([FromQuery] int userId)
        {
            return await Mediator.Send(new GetNotificationsQuery { UserId = userId, IsGetOnlyUnread = false });
        }
    }
}