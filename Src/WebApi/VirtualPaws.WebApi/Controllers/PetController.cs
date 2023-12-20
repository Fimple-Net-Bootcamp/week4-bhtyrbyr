using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using VirtualPaws.Application.DTOs.PetDTOs;
using VirtualPaws.Application.Features.Entities.Pets.Commands.Create;
using VirtualPaws.Application.Features.Entities.Pets.Commands.Delete;
using VirtualPaws.Application.Features.Entities.Pets.Commands.Update;
using VirtualPaws.Application.Features.Entities.Pets.Queries;

namespace VirtualPaws.WebApi.Controllers
{
    [Route("api/v1/VirtualPaws/[controller]s")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var query = new GetAllListQuery();
                var result = await _mediator.Send(query);
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(UInt16 id)
        {
            try
            {
                var query = new GetByIdQuery(id);
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] PetCreateDTO model)
        {
            try
            {
                var command = new CreateCommand(model);
                var result = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetById), new { id = command.newId }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(UInt16 id)
        {
            try
            {
                var command = new DeleteCommand(id);
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePut(UInt16 id, [FromBody] PetUpdateDTO model)
        {
            try
            {
                var command = new UpdateCommand(id, model);
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePatch(UInt16 id, [FromBody] JsonPatchDocument<PetUpdateDTO> model)
        {
            try
            {
                var updateDTOModel = new PetUpdateDTO();
                model.ApplyTo(updateDTOModel);
                var command = new UpdateCommand(id, updateDTOModel);
                return Ok(await _mediator.Send(command));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
