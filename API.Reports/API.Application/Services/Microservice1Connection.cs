using API.Domain.Entities;
using System.Net.Http.Json;

namespace API.Application.Services
{
    public class Microservice1Connection : IMicroservice1Connection
    {
        private readonly HttpClient _httpClient;

        public Microservice1Connection(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5200/api/");
        }

        public async Task<Person> GetPersonsMicroserviceByID(int? id)
        {
            var response = await _httpClient.GetAsync("Person/" + id);
            var persons = await response.Content.ReadFromJsonAsync<Person>();
            return persons;
        }

        public async Task<IEnumerable<Person>> GetPersonsMicroservice()
        {
            var response = await _httpClient.GetAsync("Person");
            var persons = await response.Content.ReadFromJsonAsync<List<Person>>();
            return persons;
        }
    }
}
