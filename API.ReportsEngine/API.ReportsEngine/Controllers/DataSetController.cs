using API.Application.Commands.DataSetCommands;
using API.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.ReportsEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSetController : ControllerBase
    {
        public readonly IMediator _mediator;

        public DataSetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<DataSetDTO>> CreateDataSet(CreateDataSetCommand command)
        {
            var dataSet = await _mediator.Send(command);
            return Ok(dataSet);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DataSetDTO>> UpdateDataSet(int id, UpdateDataSetCommand command)
        {
            if (id != command.id)
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
        public async Task<IActionResult> DeleteDataSet(int id)
        {
            await _mediator.Send(new DeleteDataSetCommand(id));
            return NoContent();
        }
    }
}
