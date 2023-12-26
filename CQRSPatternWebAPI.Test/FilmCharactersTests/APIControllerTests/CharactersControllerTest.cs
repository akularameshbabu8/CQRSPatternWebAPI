using API.Controllers;
using Application.Queries.FilmyCharacters.GetById;
using Domain.Models;
using Domain.Models.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CQRSPatternWebAPI.Test.FilmCharactersTests.APIControllerTests
{
   
    
    [TestFixture]
    public class CharactersControllerTest
    {
        private Mock<IMediator> _mediator;

        private CharactersController _controller;

        [SetUp]
        public void SetUp()
        {

            _mediator = new Mock<IMediator>();
            _controller = new CharactersController(_mediator.Object);

        }
        [Test]
        public async Task GetCharacterInFilm_ReturnsOk_WhenCharacterAndFilmExist()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
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
                }
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
            _mediator.Setup(y => y.Send(It.IsAny<GetFilmByIdQuery>(),default)).ReturnsAsync(filmResult);



            // Act
            var result = await _controller.GetCharacterInFilm(1, 2) as OkObjectResult;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var viewModel = result.Value as PersonViewModel;
            Assert.That(viewModel, Is.Not.Null);
            // Add more assertions for the properties of the view model
        }
    }
}
