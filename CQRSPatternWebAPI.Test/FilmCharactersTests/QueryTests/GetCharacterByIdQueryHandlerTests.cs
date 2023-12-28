using Application.FilmCharacters.Queries;
using Application.FilmCharacters.QueryHandlers;
using Domain.Models;
using Infrastructure.FilmCharactersHttpClientFactory;
using Moq;
namespace CQRSPatternWebAPI.Test.FilmCharactersTests.QueryTests
{
    [TestFixture]
    public class GetCharacterByIdQueryHandlerTests
    {


        private GetCharacterByIdQueryHandler _handler;
        private Mock<IFilmCharactersHttpClientFactory> _iHttpClientFactory;

        [SetUp]
        public void SetUp()
        {

            _iHttpClientFactory = new Mock<IFilmCharactersHttpClientFactory>();
            _handler = new GetCharacterByIdQueryHandler(_iHttpClientFactory.Object);

        }
        [Test]
        public async Task Handle_ReturnsNull_WhenCharacterIdIsNonZero()
        {
            // Arrange
            var expectedCharacter = new Person
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
            _iHttpClientFactory.Setup(repo => repo.GetCharacterById(It.IsAny<int>()))
                          .ReturnsAsync(expectedCharacter);

            var query = new GetCharacterByIdQuery(1);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(expectedCharacter.Name));
           
        }


    }
}
