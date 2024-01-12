using API.Application.Commands;
using API.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Reports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<PersonDTO>> CreatePerson(CreatePersonCommand command)
        {
            var person = await _mediator.Send(command);
            return Ok(person);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonDTO>> UpdatePerson(int id, UpdatePersonCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var updatedPerson = await _mediator.Send(command);

            if (updatedPerson == null)
            {
                return NotFound();
            }

            return Ok(updatedPerson);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            await _mediator.Send(new DeleteAreaCommand(id));
            return NoContent();
        }
    }
}