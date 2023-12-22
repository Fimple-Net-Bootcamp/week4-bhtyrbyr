using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualPaws.Application.DTOs.OperationDTOs;
using VirtualPaws.Application.Features.Operations;

namespace VirtualPaws.WebApi.Controllers
{
    [Route("api/v1/VirtualPaws/[controller]s")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IMediator _medaator;
        public OperationController(IMediator mediator)
        {
            _medaator = mediator;
        }

        [HttpPost("Login/")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var command = new LoginCommand(model);
            return Ok(await _medaator.Send(command));
        }

        [HttpPost("Ownership/")]
        public async Task<IActionResult> Ownership([FromBody] OwnershipDTO model)
        {
            var command = new OwnershipCommand(model);
            return Ok(await _medaator.Send(command));
        }
    }
}
