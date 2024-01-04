using API.Domain.Entities;
using API.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore.Query;

namespace API.Application.GrahpQL.Queries
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
