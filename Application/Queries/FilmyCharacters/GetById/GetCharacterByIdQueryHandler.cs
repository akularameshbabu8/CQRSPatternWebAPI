using Domain.Models;
using Infrastructure;
using MediatR;

namespace Application.Queries.FilmyCharacters.GetById
{
    public class GetCharacterByIdQueryHandler : IRequestHandler<GetCharacterByIdQuery, Person?>
    {
        private readonly IRepository<Person> _repository;

        public GetCharacterByIdQueryHandler()
        {
            _repository = new Repository<Person>();
        }

        public async Task<Person?> Handle(GetCharacterByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.CharacterId == 0)
            {
                return null;
            }

            return  _repository.GetById(request.CharacterId);
        }
    }
}
