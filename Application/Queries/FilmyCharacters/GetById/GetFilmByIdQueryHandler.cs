using Domain.Models;
using Infrastructure;
using MediatR;

namespace Application.Queries.FilmyCharacters.GetById
{

    public class GetFilmByIdQueryHandler : IRequestHandler<GetFilmByIdQuery, Film?>
    {
        private readonly IRepository<Film> _repository;

        public GetFilmByIdQueryHandler()
        {
            _repository = new Repository<Film>();
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
