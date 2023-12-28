using Application.FilmCharacters.Queries;
using Domain.Models;
using Infrastructure.FilmCharactersHttpClientFactory;
using MediatR;

namespace Application.FilmCharacters.QueryHandlers
{
    public class GetCharacterByIdQueryHandler : IRequestHandler<GetCharacterByIdQuery, Person?>
    {
       
        private readonly IFilmCharactersHttpClientFactory _iHttpClientFactory;
        public GetCharacterByIdQueryHandler(IFilmCharactersHttpClientFactory iHttpClientFactory)
        {
            _iHttpClientFactory = iHttpClientFactory;
        }

        public async Task<Person?> Handle(GetCharacterByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.CharacterId == 0)
            {
                return null;
            }

            return await _iHttpClientFactory.GetCharacterById(request.CharacterId);
        }
    }
}
