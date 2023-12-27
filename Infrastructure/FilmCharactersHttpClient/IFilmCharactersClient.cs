using Domain.Models;
using System.Threading.Tasks;

namespace Infrastructure.FilmCharactersHttpClient
{
    public interface IFilmCharactersClient
    {
        Task<Person> GetCharacterById(int id);
        Task<Film> GetFilmById(int id);
    }
}
