using API.Application.Commands.FieldCommands;
using API.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.ReportsEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FieldController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<FieldDTO>> CreateField(CreateFieldCommand command)
        {
            var area = await _mediator.Send(command);
            return Ok(area);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FieldDTO>> UpdatField(int id, UpdateFieldCommand command)
        {
            if (id != command.id)
            {
                return BadRequest();
            }

            var updatedField = await _mediator.Send(command);

            if (updatedField == null)
            {
                return NotFound();
            }

            return Ok(updatedField);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteField(int id)
        {
            await _mediator.Send(new DeleteFieldCommand(id));
            return NoContent();
        }
    }
}
