using API.Domain.Entities.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;

namespace API.Application.Services
{
    public class MonedaService
    {

        static HttpClient client = new HttpClient();

        public MonedaService() {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im5yb3R0YSIsImdydXBvRGVFbXByZXNhSWQiOiIxMDAwMDAwMCIsInN1Y3Vyc2FsSWQiOiIxMDAwMDAwMCIsImp0aSI6IjljMjNhZWI5LWMwMjYtNGIzMy04ODE4LWEwYmM5OGYzZmMxYyIsImlhdCI6MTcwNjAxNzg2NCwiZW1wcmVzYUlkIjoiMTAwMDAwMDAiLCJpZGlvbWFJZCI6IjEiLCJhcGVsbGlkbyI6IlJvdHRhIiwibm9tYnJlIjoiTmljb2xhcyIsIm1lbnVDb250cmFpZG8iOiJGYWxzZSIsInVzdWFyaW9JZCI6IjEwMDAwMjQxIiwiY3VsdHVyZSI6ImVzLUFSIiwidW5pZGFkRGVOZWdvY2lvSWQiOiIxMDAwMDE3MiIsImFyZWFzVGFibGFzIjoiMDswOzA7MDswOzA7MDswOzA7MCIsInRpcG9Vc3VhcmlvIjoiMSIsInBlcmZpbERlQ29tcHJvYmFudGVJZCI6IjEwMDAwMDAwIiwiZndrVXNlcklkIjoiNGJlZGNlZWYtM2NkYy00M2YxLTlmNmUtMjFiYjUwMzg0OTU1IiwiZndrVXNlclNlY3VyaXR5U3RhbXAiOiJXV1JSQVVENFJVUTVYV01MQUxWR1lIUUJWVFNON0hDVCIsImV4cCI6MTcwNjI3NzA2MywiaXNzIjoieW91cmRvbWFpbi5jb20iLCJhdWQiOiJ5b3VyZG9tYWluLmNvbSJ9.K9pZyE3gBXs2NWsFDlqFtgby3TQC4l-5qtWM4a5kjzI");
        }

        public async Task<IEnumerable<MonedaDTO>> GetAsync()
        {
            var monedas = new List<MonedaDTO>();
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:52000/api/Moneda/GetMonedas");
                response.EnsureSuccessStatusCode();
                var responseBody = JsonConvert.DeserializeObject<MonedaResponseDTO>(await response.Content.ReadAsStringAsync());

                return responseBody.result;


            }
            catch (HttpRequestException e)
            {
                return monedas;
            }
        }

    }
}
