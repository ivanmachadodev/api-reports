using API.Application.Commands.DetFieldsOfDataSetCommands;
using API.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.ReportsEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetFiesldOFDataSetController : ControllerBase
    {
        public readonly IMediator _mediator;

        public DetFiesldOFDataSetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<DetFieldsOfDataSetDTO>>> CreateDetFieldsOfDataSet(CreateDetFieldsOfDataSetCommand command)
        {
            var detFieldsOfDataSet = await _mediator.Send(command);
            return Ok(detFieldsOfDataSet);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<DetFieldsOfDataSetDTO>>> UpdateDetFieldsOfDataSet(int id, UpdateDetFieldsOfDataSetCommand command)
        {
            if (id != command.dataSetId)
            {
                return BadRequest();
            }

            var updatedDataSet = await _mediator.Send(command);

            if (updatedDataSet == null)
            {
                return NotFound();
            }

            return Ok(updatedDataSet);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetFieldsOfDataSet(int id)
        {
            await _mediator.Send(new DeleteDetFieldsOfDataSetCommand(id));
            return NoContent();
        }
    }
}
