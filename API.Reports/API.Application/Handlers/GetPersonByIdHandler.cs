using API.Application.DTOs;
using API.Application.Querys;
using API.Application.Services;
using API.Infrastructure.Contracts;
using API.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application.Handlers
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonDTO>
    {
        private readonly IPersonRepository _personRepository;
        public GetPersonByIdHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<PersonDTO> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var person = _personRepository.GetPersonById(request.id);

            if (person == null)
            {
                return null;
            }

            return new PersonDTO 
            { 
                Id = person.Id, 
                Name = person.Name, 
                LastName = person.LastName
            };

        }
    }
}
