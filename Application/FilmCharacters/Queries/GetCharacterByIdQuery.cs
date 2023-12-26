using Domain.Models;
using MediatR;

namespace Application.FilmCharacters.Queries
{
    public class GetCharacterByIdQuery : IRequest<Person>
    {
        public GetCharacterByIdQuery(int characterId)
        {
            CharacterId = characterId;
        }
        public int CharacterId { get; }
    }
}
