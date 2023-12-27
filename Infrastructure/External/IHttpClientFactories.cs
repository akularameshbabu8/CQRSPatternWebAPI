using Domain.Models;
using System.Threading.Tasks;

namespace Infrastructure.External
{
    public interface IHttpClientFactories
    {
        Task<Person> GetCharacterById(int id);
        Task<Film> GetFilmById(int id);
    }
}
