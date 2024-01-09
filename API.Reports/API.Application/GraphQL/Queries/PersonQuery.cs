using API.Domain.Entities;
using API.Infrastructure.Contracts;

namespace API.Application.GraphQL.Queries
{
    public class PersonQuery
    {
        public async Task<IEnumerable<Person>> GetPersons([Service] IPersonRepository personRepository, int? id)
        {
            if (id.HasValue)
            {
                var person = await personRepository.GetPersonByIdAsync(id);
                return person != null ? new List<Person> { person } : Enumerable.Empty<Person>();
            }
            else
            {
                return await personRepository.GetAllPersonsAsync();
            }
        }

    }
}
