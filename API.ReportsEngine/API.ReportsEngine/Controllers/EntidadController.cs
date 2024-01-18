using API.Application.Commands.EntidadCommands;
using API.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.ReportsEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EntidadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<EntidadDTO>> CreateEntidad(CreateEntidadCommand command)
        {
            var campo = await _mediator.Send(command);
            return Ok(campo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EntidadDTO>> UpdateEntidad(int id, UpdateEntidadCommand command)
        {
            if (id != command.id)
            {
                return BadRequest();
            }

            var updatedArea = await _mediator.Send(command);

            if (updatedArea == null)
            {
                return NotFound();
            }

            return Ok(updatedArea);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntidad(int id)
        {
            await _mediator.Send(new DeleteEntidadCommand(id));
            return NoContent();
        }
    }
}
