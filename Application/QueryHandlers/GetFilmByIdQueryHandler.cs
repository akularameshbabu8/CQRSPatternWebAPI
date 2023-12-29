using Application.Queries;
using Application.Services;
using Domain.Models;
using MediatR;

namespace Application.QueryHandlers
{

    public class GetFilmByIdQueryHandler : IRequestHandler<GetFilmByIdQuery, Film?>
    {
        private readonly IHttpClientService _iHttpClientService;

        public GetFilmByIdQueryHandler(IHttpClientService iHttpClientService)
        {
            _iHttpClientService = iHttpClientService;
        }

        public async Task<Film?> Handle(GetFilmByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.FilmId == 0)
            {
                return null;
            }

            return await _iHttpClientService.GetFilmById(request.FilmId);
        }
    }
}
