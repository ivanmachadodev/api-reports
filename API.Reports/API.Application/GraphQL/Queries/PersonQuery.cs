using API.Domain.Entities;
using API.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application.GraphQL.Queries
{
    public class PersonQuery
    {
        public async Task<IEnumerable<Person>> GetPersons([Service] IPersonRepository personRepository, int? id = null)
        {
            if (id.HasValue)
            {
                var person = await personRepository.GetPersonByIdAsync(id.Value);
                return person != null ? new List<Person> { person } : Enumerable.Empty<Person>();
            }
            else
            {
                return await personRepository.GetAllPersonsAsync();
            }
        }

    }
}
