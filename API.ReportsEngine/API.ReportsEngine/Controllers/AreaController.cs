using API.Application.Commands.AreaCommands;
using API.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.ReportsEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AreaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<AreaDTO>> CreateArea(CreateAreaCommand command)
        {
            var area = await _mediator.Send(command);
            return Ok(area);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AreaDTO>> UpdateArea(int id, UpdateAreaCommand command)
        {
            if (id != command.Id)
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
        public async Task<IActionResult> DeleteArea(int id)
        {
            await _mediator.Send(new DeleteAreaCommand(id));
            return NoContent();
        }
    }
}
