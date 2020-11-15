using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RainbowApp.Application.Model;
using RainbowApp.Application.Tasks.Commands;
using RainbowApp.Core.Entities;

namespace RainbowApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiController
    {
        [HttpPost("authenticate")]
        public async Task<ActionResult<TblMember>> Authenticate(AuthenticateRequest model)
        {
            var response = await Mediator.Send(new CreateAuthCommand { MailAddr = model.MailAddr, Password = model.Password });
            if (response == null)
                return BadRequest(new { message = "MailAddr or password is incorrect" });

            return Ok(response);
        }
    }
}