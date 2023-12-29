using Domain.Models;

namespace Application.Services
{
    public  interface IHttpClientService
    {
        Task<Person> GetCharacterById(int id);
        Task<Film> GetFilmById(int id);
    }
}
