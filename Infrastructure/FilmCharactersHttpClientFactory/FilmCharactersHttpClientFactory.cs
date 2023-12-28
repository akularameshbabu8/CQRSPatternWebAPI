using Domain.Models;
using Newtonsoft.Json;
namespace Infrastructure.FilmCharactersHttpClientFactory
{
    public class FilmCharactersHttpClientFactory : IFilmCharactersHttpClientFactory
    {
        public readonly IHttpClientFactory _factory;
        
        public FilmCharactersHttpClientFactory(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<Person> GetCharacterById(int Id)
        {
           
            var client = _factory.CreateClient("people");
            
            var result = await client.GetAsync($"{Id}");

            var resultContent = await result.Content.ReadAsStringAsync();

            var resultObject = JsonConvert.DeserializeObject<Person>(resultContent);
            return resultObject;

        }
        public async Task<Film> GetFilmById(int Id)
        {
            var client = _factory.CreateClient("films");

            var result = await client.GetAsync($"{Id}");

            var resultContent = await result.Content.ReadAsStringAsync();

            var resultObject = JsonConvert.DeserializeObject<Film>(resultContent);
            return resultObject;

        }
    }
}
