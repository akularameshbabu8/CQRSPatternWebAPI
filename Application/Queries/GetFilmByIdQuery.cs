using Domain.Models;
using MediatR;

namespace Application.Queries
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
