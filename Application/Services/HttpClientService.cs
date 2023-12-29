using Domain.Models;
using System.Text.Json;

namespace Application.Services
{
    public class HttpClientService: IHttpClientService
    {
        private readonly IHttpClientFactory _factory;

        public HttpClientService(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public Task<Person> GetCharacterById(int id) => GetEntityById<Person>("people", id);

        public Task<Film> GetFilmById(int id) => GetEntityById<Film>("films", id);

        private async Task<T> GetEntityById<T>(string clientName, int id)
        {
            var client = _factory.CreateClient(clientName);
            var result = await client.GetAsync($"{id}");

            result.EnsureSuccessStatusCode();

            var resultContent = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(resultContent);
        }
    }
}
