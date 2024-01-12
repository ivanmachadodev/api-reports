using API.Application.Commands.Person;
using API.Application.DTOs;
using API.Domain.Entities;
using API.Infrastructure.Contracts;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Execution.Processing;
using HotChocolate.Language;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Reports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRequestExecutor _executor;

        public PersonController(IMediator mediator, IRequestExecutor executor)
        {
            _mediator = mediator;
            _executor = executor;
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
            await _mediator.Send(new DeletePersonCommand(id));
            return NoContent();
        }
    }
}