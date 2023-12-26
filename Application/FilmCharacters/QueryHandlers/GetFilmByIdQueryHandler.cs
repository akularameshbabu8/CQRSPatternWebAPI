using Application.FilmCharacters.Queries;
using Domain.Models;
using Infrastructure;
using MediatR;

namespace Application.FilmCharacters.QueryHandlers
{

    public class GetFilmByIdQueryHandler : IRequestHandler<GetFilmByIdQuery, Film?>
    {
        private readonly IRepository<Film> _repository;

        public GetFilmByIdQueryHandler(IRepository<Film> repository)
        {
            _repository = repository;
        }

        public async Task<Film?> Handle(GetFilmByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.FilmId == 0)
            {
                return null;
            }

            return _repository.GetById(request.FilmId);
        }
    }
}
