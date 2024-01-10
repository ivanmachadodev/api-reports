using API.Domain.Entities;

namespace API.Application.Services
{
    public interface IMicroservice1Connection
    {
        Task<Person> GetPersonsMicroserviceByID(int? id);
        Task<IEnumerable<Person>> GetPersonsMicroservice();
    }
}
