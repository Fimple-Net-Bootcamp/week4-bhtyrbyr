using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualPaws.Application.DTOs.UserDTOs;
using VirtualPaws.Application.Features.Entities.Users.Commands.Create;
using VirtualPaws.Application.Features.Entities.Users.Commands.Delete;
using VirtualPaws.Application.Features.Entities.Users.Queries;

namespace VirtualPaws.WebApi.Controllers
{
    [Route("api/v1/VirtualPaws/[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllListQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(UInt16 id)
        {
            var query = new GetByIdQuery(id);
            return Ok(await _mediator.Send(query));
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] UserCreateDTO model)
        {
            var command = new CreateCommand(model);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = command.newId }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(UInt16 id)
        {
            var command = new DeleteCommand(id);
            return Ok(await _mediator.Send(command));
        }
    }
}
