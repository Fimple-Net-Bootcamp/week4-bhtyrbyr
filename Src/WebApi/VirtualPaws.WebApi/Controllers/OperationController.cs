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
        private readonly IMediator _mediator;
        public OperationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login/")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var command = new LoginCommand(model);
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("Ownership/")]
        public async Task<IActionResult> Ownership([FromBody] OwnershipDTO model)
        {
            var command = new OwnershipCommand(model);
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("DoActivity/")]
        public async Task<IActionResult> DoActivity([FromBody] DoActivityDTO model)
        {
            var command = new DoActivityCommand(model);
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("FeedPet/")]
        public async Task<IActionResult> PetFeed([FromBody] FeedPetDTO model)
        {
            var command = new FeedPetCommand(model);
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("Training/")]
        public async Task<IActionResult> TrainigPet([FromBody] TrainingDTO model)
        {
            var command = new TrainingCommand(model);
            return Ok(await _mediator.Send(command));
        }
    }
}
