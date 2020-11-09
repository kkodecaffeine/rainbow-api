using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RainbowApp.Core.Entities;

namespace RainbowApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Notification>>> GetAll()
        {
            return await Mediator.Send(new GetAllTasksQuery());
        }
    }
}