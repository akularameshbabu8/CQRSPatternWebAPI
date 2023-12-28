using Domain.Models;
using Infrastructure.FilmCharactersHttpClientFactory;

namespace Application.Abstractions
{
    public  class Repository : IRepository
    {
        
        private readonly IFilmCharactersHttpClientFactory _iHttpClientFactory;

        public Repository(IFilmCharactersHttpClientFactory iHttpClientFactory)
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
