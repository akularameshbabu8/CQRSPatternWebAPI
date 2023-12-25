using Domain.Models;
using MediatR;

namespace Application.Queries.Persons.GetById
{
    public class GetPersonByIdQuery : IRequest<Person>
    {
        public GetPersonByIdQuery(int characterId)
        {
            CharacterId = characterId;
        }
        public int CharacterId { get; }
    }
}
