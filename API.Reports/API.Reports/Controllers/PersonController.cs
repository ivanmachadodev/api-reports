using API.Application.Commands.Person;
using API.Application.DTOs;
using API.Application.Querys.Person;
using API.Infrastructure.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Reports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPersonRepository _personRepository;

        public PersonController(IMediator mediator, IPersonRepository personRepository)
        {
            _mediator = mediator;
            _personRepository = personRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDTO>> GetById(int id)
        {
            var query = new GetPersonByIdQuery(id);
            var person = await _mediator.Send(query);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> GetAll()
        {
            var query = new GetAllPersonsQuery();
            var persons = await _mediator.Send(query);
            return Ok(persons);
        }

        [HttpPost]
        public async Task<ActionResult<PersonDTO>> CreatePerson(CreatePersonCommand command)
        {
            var person = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
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