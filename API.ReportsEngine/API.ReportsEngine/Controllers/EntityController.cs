using API.Application.Commands.EntidadCommands;
using API.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.ReportsEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EntityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<EntityDTO>> CreateEntity(CreateEntityCommand command)
        {
            var entity = await _mediator.Send(command);
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EntityDTO>> UpdateEntity(int id, UpdateEntityCommand command)
        {
            if (id != command.id)
            {
                return BadRequest();
            }

            var updatedEntity = await _mediator.Send(command);

            if (updatedEntity == null)
            {
                return NotFound();
            }

            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntity(int id)
        {
            await _mediator.Send(new DeleteEntityCommand(id));
            return NoContent();
        }
    }
}
