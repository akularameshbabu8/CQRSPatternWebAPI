using Application.Abstractions;
using Application.FilmCharacters.Queries;
using Application.FilmCharacters.QueryHandlers;
using Domain.Models;
using Moq;

namespace CQRSPatternWebAPI.Test.FilmCharactersTests.QueryTests
{
    [TestFixture]
    public class GetFilmByIdQueryHandlerTests
    {


        private GetFilmByIdQueryHandler _handler;
        private Mock<IRepository> _repository;

        [SetUp]
        public void SetUp()
        {

            _repository = new Mock<IRepository>();
            _handler = new GetFilmByIdQueryHandler(_repository.Object);

        }
        [Test]
        public async Task Handle_ReturnsFilm_WhenFilmIdIsNonZero()
        {
            // Arrange           

            var expectedFilm = new Film
            {
                Characters = new List<string>
                {
                    { "https://swapi.dev/api/people/1/" },
                    { "https://swapi.dev/api/people/2/" },
                    { "https://swapi.dev/api/people/3/" },
                    { "https://swapi.dev/api/people/4/" },
                    { "https://swapi.dev/api/people/5/"},
                    { "https://swapi.dev/api/people/6/" },
                    { "https://swapi.dev/api/people/7/" },
                    { "https://swapi.dev/api/people/8/" },
                    { "https://swapi.dev/api/people/9/" },
                    { "https://swapi.dev/api/people/10/" },
                    { "https://swapi.dev/api/people/12/" },
                    { "https://swapi.dev/api/people/13/" },
                    { "https://swapi.dev/api/people/14/" },
                    { "https://swapi.dev/api/people/15/" },
                    { "https://swapi.dev/api/people/16/" },
                    { "https://swapi.dev/api/people/18/" },
                    { "https://swapi.dev/api/people/19/" },
                    { "https://swapi.dev/api/people/81/" }
                }

            };
            _repository.Setup(repo => repo.GetFilmById(It.IsAny<int>()))
                          .ReturnsAsync(expectedFilm);

            var query = new GetFilmByIdQuery(1);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Characters.Count, Is.EqualTo(expectedFilm.Characters.Count));
        }


    }
}

