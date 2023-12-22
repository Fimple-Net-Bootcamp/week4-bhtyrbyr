using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualPaws.Application.Features.Records;

namespace VirtualPaws.WebApi.Controllers
{
    [Route("api/v1/VirtualPaws/[controller]s")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Activities/")]
        public async Task<IActionResult> GetActivitiesRecord()
        {
            var query = new ActivityRecordCommand();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("Feeds/")]
        public async Task<IActionResult> GetFeedsRecord()
        {
            var query = new FeedRecordCommand();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("Ownerships/")]
        public async Task<IActionResult> GetOwnershipsRecord()
        {
            var query = new OwnershipRecordCommand();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("Trainings/")]
        public async Task<IActionResult> GetTrainingsRecord()
        {
            var query = new TrainingRecordCommand();
            return Ok(await _mediator.Send(query));
        }
    }
}
