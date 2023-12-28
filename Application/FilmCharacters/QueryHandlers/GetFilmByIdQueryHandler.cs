using Application.FilmCharacters.Queries;
using Domain.Models;
using Infrastructure.FilmCharactersHttpClientFactory;
using MediatR;

namespace Application.FilmCharacters.QueryHandlers
{

    public class GetFilmByIdQueryHandler : IRequestHandler<GetFilmByIdQuery, Film?>
    {
        private readonly IFilmCharactersHttpClientFactory _iHttpClientFactory;

        public GetFilmByIdQueryHandler(IFilmCharactersHttpClientFactory iHttpClientFactory)
        {
            _iHttpClientFactory = iHttpClientFactory;
        }

        public async Task<Film?> Handle(GetFilmByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.FilmId == 0)
            {
                return null;
            }

            return await _iHttpClientFactory.GetFilmById(request.FilmId);
        }
    }
}
