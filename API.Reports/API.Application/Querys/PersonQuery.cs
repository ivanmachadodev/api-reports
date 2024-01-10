using API.Application.Services;
using API.Domain.Entities;
using API.Infrastructure.Contracts;

namespace API.Application.Querys
{
  
    [ExtendObjectType("Query")]
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

        public async Task<IEnumerable<Person>> GetPersons2([Service] IMicroservice1Connection microservice1Connection, int? id)
        {
            if (id.HasValue)
            {
                var person = await microservice1Connection.GetPersonsMicroserviceByID(id);
                return person != null ? new List<Person> { person } : Enumerable.Empty<Person>();
            }
            else
            {
                return await microservice1Connection.GetPersonsMicroservice();
            }
        }

    }
}
