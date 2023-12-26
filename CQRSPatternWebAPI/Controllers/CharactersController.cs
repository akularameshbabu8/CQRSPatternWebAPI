using Application.Queries.FilmyCharacters.GetById;
using Domain.Models;
using Domain.Models.Domain.Models;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    public class CharactersController : ControllerBase
    {
        internal readonly IMediator _mediator;
        public CharactersController(IMediator mediator)
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

                    var response = new PersonViewModel()
                    {
                        Name = characterResult.Name,
                        BirthYear=characterResult.BirthYear,
                        EyeColor=characterResult.EyeColor,
                        Gender=characterResult.Gender,
                        HairColor=characterResult.HairColor,
                        Height=characterResult.Height,
                        Mass=characterResult.Mass,
                        SkinColor=characterResult.SkinColor,
                        filmsCount= characterResult.Films.Count,
                        vehiclesCount= characterResult.Vehicles.Count,                       
                        starshipsCount = characterResult.Starships.Count
                    };

                    return Ok(response);
                }
            }

            return NotFound("No characters available with in this film");
        }



    }
}
