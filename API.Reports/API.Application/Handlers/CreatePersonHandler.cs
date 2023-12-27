using API.Application.Commands;
using API.Application.DTOs;
using API.Application.Services;
using API.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application.Handlers
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, PersonDTO>
    {
        private readonly PersonRepositoy _personService;
        public CreatePersonHandler(PersonRepositoy personService) 
        {
            _personService = personService;
        }

        public async Task<PersonDTO> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                Name =  request.name,
                LastName = request.lastName
            };

            _personService.SavePerson(person);

            return new PersonDTO
            {
                Id = person.Id,
                Name = person.Name,
                LastName = person.LastName
            };
        }
    }
}
