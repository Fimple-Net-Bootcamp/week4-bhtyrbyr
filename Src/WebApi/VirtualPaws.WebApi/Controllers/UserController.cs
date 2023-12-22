﻿using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using VirtualPaws.Application.DTOs.UserDTOs;
using VirtualPaws.Application.Features.Entities.Users.Commands.Create;
using VirtualPaws.Application.Features.Entities.Users.Commands.Delete;
using VirtualPaws.Application.Features.Entities.Users.Commands.Update;
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
        public async Task<IActionResult> Create([FromBody] UserCreateDTO model)
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
        public async Task<IActionResult> UpdatePut(UInt16 id, [FromBody] UserUpdateDTO model)
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
        public async Task<IActionResult> UpdatePatch(UInt16 id, [FromBody] JsonPatchDocument<UserUpdateDTO> model)
        {
            try
            {
                var updateDTOModel = new UserUpdateDTO();
                model.ApplyTo(updateDTOModel);
                var command = new UpdateCommand(id, updateDTOModel);
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
