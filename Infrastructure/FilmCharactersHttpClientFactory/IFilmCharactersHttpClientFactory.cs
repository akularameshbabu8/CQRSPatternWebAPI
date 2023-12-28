using Domain.Models;
using System.Threading.Tasks;

namespace Infrastructure.FilmCharactersHttpClientFactory
{
    public interface IFilmCharactersHttpClientFactory
    {
        Task<Person> GetCharacterById(int id);
        Task<Film> GetFilmById(int id);
    }
}
