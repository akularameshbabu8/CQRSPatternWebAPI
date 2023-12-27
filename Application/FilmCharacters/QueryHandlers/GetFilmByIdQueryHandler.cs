using Application.Abstractions;
using Application.FilmCharacters.Queries;
using Domain.Models;
using MediatR;

namespace Application.FilmCharacters.QueryHandlers
{

    public class GetFilmByIdQueryHandler : IRequestHandler<GetFilmByIdQuery, Film?>
    {
        private readonly IRepository _repository;

        public GetFilmByIdQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Film?> Handle(GetFilmByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.FilmId == 0)
            {
                return null;
            }

            return await _repository.GetFilmById(request.FilmId);
        }
    }
}
