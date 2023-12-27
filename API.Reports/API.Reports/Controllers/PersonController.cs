using API.Application.Commands;
using API.Application.DTOs;
using API.Application.Querys;
using MediatR;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public async Task<ActionResult<PersonDTO>> CreatePerson(CreatePersonCommand command)
        {
            var person = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }
    }
}
