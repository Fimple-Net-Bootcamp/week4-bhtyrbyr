using MediatR;
using Microsoft.AspNetCore.Mvc;
using VirtualPaws.Application.Features.Entities.Activities.Queries;

namespace VirtualPaws.WebApi.Controllers
{
    [Route("api/v1/VirtualPaws/[controller]s")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ActivityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var query = new GetAllListQuery();
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
