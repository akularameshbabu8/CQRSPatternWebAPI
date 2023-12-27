using Domain.Models;
using Infrastructure.External;

namespace Application.Abstractions
{
    public  class Repository : IRepository
    {
        
        private readonly IHttpClientFactories _iHttpClientFactory;

        public Repository(IHttpClientFactories iHttpClientFactory)
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
