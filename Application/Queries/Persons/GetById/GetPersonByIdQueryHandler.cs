using Domain.Models;
using Infrastructure;
using MediatR;

namespace Application.Queries.Persons.GetById
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, Person?>
    {
        private readonly IRepository<Person> _repository;

        public GetPersonByIdQueryHandler()
        {
            _repository = new Repository<Person>();
        }

        public async Task<Person?> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.CharacterId == 0)
            {
                return null;
            }

            return  _repository.GetById(request.CharacterId);
        }
    }
}
