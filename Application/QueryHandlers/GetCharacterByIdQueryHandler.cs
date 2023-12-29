using Application.Queries;
using Domain.Models;
using Application.Services;
using MediatR;

namespace Application.QueryHandlers
{
    public class GetCharacterByIdQueryHandler : IRequestHandler<GetCharacterByIdQuery, Person?>
    {

        private readonly IHttpClientService _iHttpClientService;
        public GetCharacterByIdQueryHandler(IHttpClientService iHttpClientService)
        {
            _iHttpClientService = iHttpClientService;
        }

        public async Task<Person?> Handle(GetCharacterByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.CharacterId == 0)
            {
                return null;
            }

            return await _iHttpClientService.GetCharacterById(request.CharacterId);
        }
    }
}
