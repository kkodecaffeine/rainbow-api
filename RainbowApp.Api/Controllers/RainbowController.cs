using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using RainbowApp.Application.Tasks.Commands;
using RainbowApp.Application.Tasks.Dto;
using RainbowApp.Application.Tasks.Queries;

namespace RainbowApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RainbowController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTaskCommand command)
        {
            return await Mediator.Send(command);
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ServiceProviderDto>>> GetAll()
        {
            return await Mediator.Send(new GetAllTasksQuery());
        }

        //[HttpGet("/{id}")]
        //public async Task<ActionResult<TaskDto>> Get(int id)
        //{
        //    return await Mediator.Send(new GetTaskByIdQuery { Id = id });
        //}

        //[HttpPut]
        //public async Task<ActionResult<int>> Update(UpdateTaskCommand command)
        //{
        //    return await Mediator.Send(command);
        //}

        //[HttpDelete]
        //public async Task<ActionResult<int>> Delete(int id)
        //{
        //    return await Mediator.Send(new DeleteTaskCommand { Id = id });
        //}
    }
}