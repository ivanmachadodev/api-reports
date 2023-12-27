using API.Application.Commands;
using API.Domain.Entities;
using API.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application.Services
{
    public class PersonRepositoy
    {
        private readonly IPersonRepository _personRepository;

        public PersonRepositoy(IPersonRepository PersonRepository)
        {
            _personRepository = PersonRepository;
        }

        public Person? GetPersonById(int id)
        {
            return _personRepository.GetPersonById(id);
        }

        public void SavePerson(Person person)
        {
            _personRepository.SavePerson(person);
        }

        public void EditPerson(Person person)
        {
            _personRepository.EditPerson(person);
        }

        public void DeletePerson(Person person)
        {
            _personRepository.DeletePerson(person);
        }
    }
}
