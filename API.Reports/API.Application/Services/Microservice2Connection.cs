using API.Application.DTOs;
using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace API.Application.Services
{
    public class Microservice2Connection :IMicroservice2Connection
    {
        private readonly HttpClient _httpClient;

        public Microservice2Connection(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5300/api/");
        }

        public async Task<ItemDTO> GetItemMicroserviceByID(int? id)
        {
            var response = await _httpClient.GetAsync("Item/" + id);
            var item = await response.Content.ReadFromJsonAsync<ItemDTO>();
            return item;
        }

        public async Task<IEnumerable<ItemDTO>> GetItemsMicroservice()
        {
            var response = await _httpClient.GetAsync("Item");
            var items = await response.Content.ReadFromJsonAsync<List<ItemDTO>>();
            return items;
        }
    }
}
