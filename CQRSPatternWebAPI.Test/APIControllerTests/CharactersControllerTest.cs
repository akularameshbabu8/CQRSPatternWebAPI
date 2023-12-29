using API.Controllers;
using Application.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace CQRSPatternWebAPI.Test.APIControllerTests
{


    [TestFixture]
    public class CharactersControllerTest
    {
        private Mock<IMediator> _mediator;
        private Mock<ILogger<CharactersController>> _logger;

        private CharactersController _controller;

        [SetUp]
        public void SetUp()
        {
            _logger = new Mock<ILogger<CharactersController>>();
            _mediator = new Mock<IMediator>();
            _controller = new CharactersController(_mediator.Object, _logger.Object);

        }
        [Test]
        public async Task GetCharacterInFilm_ReturnsOk_WhenCharacterAndFilmExist()
        {
            // Arrange            
            var characterResult = new Person
            {
                Name = "Luke Skywalker",
                BirthYear = "19BBY",
                EyeColor = "blue",
                Gender = "male",
                HairColor = "blond",
                Height = "172",
                Mass = "77",
                SkinColor = "fair",
                Homeworld = "https://swapi.dev/api/planets/1/",
                Films = new List<string>
                {
                    { "https://swapi.dev/api/films/1/" },
                    { "https://swapi.dev/api/films/2/" },
                    { "https://swapi.dev/api/films/3/" },
                    { "https://swapi.dev/api/films/6/" }
                },
                Species = new List<string> { },
                Starships = new List<string> {
                    { "https://swapi.dev/api/starships/12/" },
                    { "https://swapi.dev/api/starships/22/" }
                },
                Vehicles = new List<string> {
                    {"https://swapi.dev/api/vehicles/14/" },
                    { "https://swapi.dev/api/vehicles/30/" }
                },
                Url = "https://swapi.dev/api/people/1/"
            };
            _mediator.Setup(m => m.Send(It.IsAny<GetCharacterByIdQuery>(), default)).ReturnsAsync(characterResult);

            var filmResult = new Film
            {
                Characters = new List<string>
                {
                    { "https://swapi.dev/api/people/1/" },
                    { "https://swapi.dev/api/people/2/" }
                }
            };
            _mediator.Setup(y => y.Send(It.IsAny<GetFilmByIdQuery>(), default)).ReturnsAsync(filmResult);
            // Act
            var result = await _controller.GetCharacterInFilm(1, 2) as OkObjectResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));

        }
        [Test]
        public async Task GetCharacterInFilm_ReturnsNotFound_WhenCharacterNotFoundInFilm()
        {
            // Arrange
            var filmId = 1;
            var characterId = 2;
            var characterResult = new Person
            {
                Name = "Luke Skywalker",
                BirthYear = "19BBY",
                EyeColor = "blue",
                Gender = "male",
                HairColor = "blond",
                Height = "172",
                Mass = "77",
                SkinColor = "fair",
                Homeworld = "https://swapi.dev/api/planets/1/",
                Films = new List<string>
                {
                    { "https://swapi.dev/api/films/1/" },
                    { "https://swapi.dev/api/films/2/" },
                    { "https://swapi.dev/api/films/3/" },
                    { "https://swapi.dev/api/films/6/" }
                },
                Species = new List<string> { },
                Starships = new List<string> {
                    { "https://swapi.dev/api/starships/12/" },
                    { "https://swapi.dev/api/starships/22/" }
                },
                Vehicles = new List<string> {
                    {"https://swapi.dev/api/vehicles/14/" },
                    { "https://swapi.dev/api/vehicles/30/" }
                },
                Url = "https://swapi.dev/api/people/1/"
            };
            var filmResult = new Film
            {
                Characters = new List<string>
                {


                }
            };
            _mediator.Setup(m => m.Send(It.IsAny<GetFilmByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(filmResult);
            _mediator.Setup(m => m.Send(It.IsAny<GetCharacterByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(characterResult);
            // Act
            var result = await _controller.GetCharacterInFilm(filmId, characterId);

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
            var notFoundResult = (NotFoundObjectResult)result;
            Assert.That("Character not found in the specified film.", Is.EqualTo(notFoundResult.Value));
        }
        [Test]
        public async Task GetCharacterInFilm_ReturnsNotFound_WhenFilmNotFound()
        {
            // Arrange
            var filmId = 1;
            var characterId = 2;
            var characterResult = new Person
            {
                Name = "Luke Skywalker",
                BirthYear = "19BBY",
                EyeColor = "blue",
                Gender = "male",
                HairColor = "blond",
                Height = "172",
                Mass = "77",
                SkinColor = "fair",
                Homeworld = "https://swapi.dev/api/planets/1/",
                Films = new List<string>
                {
                    { "https://swapi.dev/api/films/1/" },
                    { "https://swapi.dev/api/films/2/" },
                    { "https://swapi.dev/api/films/3/" },
                    { "https://swapi.dev/api/films/6/" }
                },
                Species = new List<string> { },
                Starships = new List<string> {
                    { "https://swapi.dev/api/starships/12/" },
                    { "https://swapi.dev/api/starships/22/" }
                },
                Vehicles = new List<string> {
                    {"https://swapi.dev/api/vehicles/14/" },
                    { "https://swapi.dev/api/vehicles/30/" }
                },
                Url = "https://swapi.dev/api/people/1/"
            };
            var filmResult = new Film
            {


            };

            _mediator.Setup(m => m.Send(It.IsAny<GetFilmByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(filmResult);
            _mediator.Setup(m => m.Send(It.IsAny<GetCharacterByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(characterResult);
            // Act
            var result = await _controller.GetCharacterInFilm(filmId, characterId);

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
            var notFoundResult = (NotFoundObjectResult)result;
            Assert.That("Film not found.", Is.EqualTo(notFoundResult.Value));
        }
        [Test]
        public async Task GetCharacterInFilm_ReturnsInternalServerError_OnException()
        {
            // Arrange
            var filmId = 1;
            var characterId = 2;

            // Setup mock behavior for GetFilmByIdQuery
            _mediator.Setup(m => m.Send(It.IsAny<GetFilmByIdQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("exception"));
            // Act
            var result = await _controller.GetCharacterInFilm(filmId, characterId);

            // Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var internalServerErrorResult = (ObjectResult)result;
            Assert.That(500, Is.EqualTo(internalServerErrorResult.StatusCode));
            Assert.That("Internal Server Error", Is.EqualTo(internalServerErrorResult.Value));
        }
    }
}
