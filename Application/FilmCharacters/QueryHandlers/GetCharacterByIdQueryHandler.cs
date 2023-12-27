using Application.FilmCharacters.Queries;
using Domain.Models;
using Application.Abstractions;
using MediatR;

namespace Application.FilmCharacters.QueryHandlers
{
    public class GetCharacterByIdQueryHandler : IRequestHandler<GetCharacterByIdQuery, Person?>
    {
        private readonly IRepository _repository;

        public GetCharacterByIdQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Person?> Handle(GetCharacterByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.CharacterId == 0)
            {
                return null;
            }

            return await _repository.GetCharacterById(request.CharacterId);
        }
    }
}
