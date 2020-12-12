using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RainbowApp.Application.Model;
using RainbowApp.Application.Tasks.Commands;
using RainbowApp.Application.Tasks.Queries;
using RainbowApp.Core.Entities;
using RainbowApp.Infrastructure.Filters;

namespace RainbowApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiController
    {
        [HttpPost("authenticate")]
        public async Task<ActionResult<TblAccount>> Authenticate(AuthenticateRequest model)
        {
            var response = await Mediator.Send(new CreateAuthCommand { Email = model.Email, Password = model.Password });
            if (response == null)
            {
                return BadRequest(new { message = "Email or password is incorrect" });
            }

            return Ok(response);
        }
        
        [HttpGet]
        public async Task<ActionResult<TblAccount>> GetAccount(SignInRequest model)
        {
            var response = await Mediator.Send(new GetAccountsQuery { Email = model.Email, Password = model.Password });
            if (response[0] == null)
            {
                return BadRequest(new { message = "Email or password is incorrect" });
            }

            return Ok(response[0]);
        }

        [HttpPost("add")]
        [CustomExceptionFilter]
        public async Task<ActionResult<int>> Create(RegisterRequest model)
        {
            return await Mediator.Send(new CreateAccountCommand { RegisterRequest = model, Origin = Request.Headers["origin"] });
        }

        // POST   /api/v1/account/password    - To create new password(if user has reset the password)

        /// <summary>
        /// Reset the current password (in case user forget the password)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete("password")]
        public async Task<ActionResult<int>> Create(ForgotPasswordRequest model)
        {
            return await Mediator.Send(new CreateForgotPasswordCommand { ForgotPasswordRequest = model, Origin = Request.Headers["origin"] });
        }

        /// <summary>
        /// Update the password (if user knows is old password and new password)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("userId/{userId}/password")]
        public async Task<ActionResult<int>> Create(int userId, ResetPasswordRequest model)
        {
            return await Mediator.Send(new CreateResetPasswordCommand { ResetPasswordRequest = model, UserId = userId });
        }
    }
}