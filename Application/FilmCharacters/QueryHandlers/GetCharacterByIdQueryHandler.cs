using Application.FilmCharacters.Queries;
using Domain.Models;
using Infrastructure;
using MediatR;

namespace Application.FilmCharacters.QueryHandlers
{
    public class GetCharacterByIdQueryHandler : IRequestHandler<GetCharacterByIdQuery, Person?>
    {
        private readonly IRepository<Person> _repository;

        public GetCharacterByIdQueryHandler(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public async Task<Person?> Handle(GetCharacterByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.CharacterId == 0)
            {
                return null;
            }

            return _repository.GetById(request.CharacterId);
        }
    }
}
