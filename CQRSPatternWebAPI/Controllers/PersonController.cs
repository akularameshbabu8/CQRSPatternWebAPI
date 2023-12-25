using Application.Queries.FilmyCharacters.GetById;
using Domain.Models;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    public class PersonController : ControllerBase
    {
        internal readonly IMediator _mediator;
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("/swapi/films/{filmId}/characters/{characterId}")]
        public async Task<IActionResult> GetCharacterInFilm(int filmId, int characterId)
        {
            var characterQuery = new GetCharacterByIdQuery(characterId);
            var characterResult = await _mediator.Send(characterQuery);

            if (characterResult != null)
            {
                var filmQuery = new GetFilmByIdQuery(filmId);
                var filmResult = await _mediator.Send(filmQuery);

                if (filmResult != null && filmResult.Characters.Count > 0)
                {
                    return Ok(characterResult);
                }
            }

            return NotFound();
        }



    }
}
