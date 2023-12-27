using Domain.Models;

namespace Application.Abstractions
{
    public interface IRepository 
    {
        Task<Person> GetCharacterById(int id);
        Task<Film> GetFilmById(int id);
    }
}
