using Domain.Models;
using MediatR;

namespace Application.FilmCharacters.Queries
{
    public class GetFilmByIdQuery : IRequest<Film>
    {
        public GetFilmByIdQuery(int filmId)
        {
            FilmId = filmId;
        }
        public int FilmId { get; }
    }
}
