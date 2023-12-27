using Domain.Models;
using Infrastructure.FilmCharactersHttpClient;

namespace Application.Abstractions
{
    public  class Repository : IRepository
    {
        
        private readonly IFilmCharactersClient _iHttpClientFactory;

        public Repository(IFilmCharactersClient iHttpClientFactory)
        {
            
            _iHttpClientFactory = iHttpClientFactory;
        }
        public Task<Person> GetCharacterById(int Id)
        {
            return _iHttpClientFactory.GetCharacterById(Id);
        }

        public Task<Film> GetFilmById(int Id)
        {
            return _iHttpClientFactory.GetFilmById(Id);
        }
    }
}
