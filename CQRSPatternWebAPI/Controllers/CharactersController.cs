using Application.FilmCharacters.Queries;
using Domain.Models.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Fluent;
namespace API.Controllers
{

    [ApiController]
    public class CharactersController : ControllerBase
    {
        private static ILogger<CharactersController> _logger;
        internal readonly IMediator _mediator;
        public CharactersController(IMediator mediator, ILogger<CharactersController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpGet]
        [Route("/swapi/films/{filmId}/characters/{characterId}")]
        public async Task<IActionResult> GetCharacterInFilm(int filmId, int characterId)
        {
            _logger.LogInformation("Requested Film/Charcter API's");
            try
            {
                var characterQuery = new GetCharacterByIdQuery(characterId);
                var characterResult = await _mediator.Send(characterQuery);

                if (characterResult.Url != null)
                {
                    var filmQuery = new GetFilmByIdQuery(filmId);
                    var filmResult = await _mediator.Send(filmQuery);

                    if (filmResult.Characters != null && filmResult.Characters.Contains(characterResult.Url))
                    {
                        var response = new PersonViewModel()
                        {
                            Name = characterResult.Name,
                            BirthYear = characterResult.BirthYear,
                            EyeColor = characterResult.EyeColor,
                            Gender = characterResult.Gender,
                            HairColor = characterResult.HairColor,
                            Height = characterResult.Height,
                            Mass = characterResult.Mass,
                            SkinColor = characterResult.SkinColor,
                            filmsCount = characterResult.Films.Count,
                            vehiclesCount = characterResult.Vehicles.Count,
                            starshipsCount = characterResult.Starships.Count
                        };

                        return Ok(response);
                    }
                    else
                    {
                        _logger.LogInformation("Thrown Exception");
                        throw new InvalidOperationException($"Character with people Id {characterId} not available in film {filmId}");
                    }
                }

                throw new InvalidOperationException($"Character with people Id {characterId} not found");
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return StatusCode(500, ex.Message);
            }

        }
    }
}