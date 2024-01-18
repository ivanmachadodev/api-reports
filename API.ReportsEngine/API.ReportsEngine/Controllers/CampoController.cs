using API.Application.Commands.CampoCommands;
using API.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.ReportsEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CampoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CampoDTO>> CreateCampo(CreateCampoCommand command)
        {
            var area = await _mediator.Send(command);
            return Ok(area);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CampoDTO>> UpdateItem(int id, UpdateCampoCommand command)
        {
            if (id != command.id)
            {
                return BadRequest();
            }

            var updatedCampo = await _mediator.Send(command);

            if (updatedCampo == null)
            {
                return NotFound();
            }

            return Ok(updatedCampo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampo(int id)
        {
            await _mediator.Send(new DeleteCampoCommand(id));
            return NoContent();
        }
    }
}
