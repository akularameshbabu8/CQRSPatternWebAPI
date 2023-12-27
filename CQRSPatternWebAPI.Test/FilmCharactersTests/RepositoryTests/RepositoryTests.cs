using Application.Abstractions;
using Domain.Models;
using Infrastructure.FilmCharactersHttpClient;
using Moq;
namespace CQRSPatternWebAPI.Test.FilmCharactersTests.RepositoryTests
{
    [TestFixture]
    public class RepositoryTests
    {
        [Test]
        public async Task GetCharacterById_ShouldReturnPerson()
        {
            // Arrange
            var httpClientFactoryMock = new Mock<IFilmCharactersClient>();
            var expectedPerson = new Person { Name = "John Doe" };
            httpClientFactoryMock.Setup(factory => factory.GetCharacterById(It.IsAny<int>())).ReturnsAsync(expectedPerson);

            var repository = new Repository(httpClientFactoryMock.Object);

            // Act
            var result = await repository.GetCharacterById(1);
           

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(expectedPerson.Name));
        }

        [Test]
        public async Task GetFilmById_ShouldReturnFilm()
        {
            // Arrange
            var httpClientFactoryMock = new Mock<IFilmCharactersClient>();
            var expectedFilm = new Film { Title = "Star Wars" };
            httpClientFactoryMock.Setup(factory => factory.GetFilmById(It.IsAny<int>())).ReturnsAsync(expectedFilm);

            var repository = new Repository(httpClientFactoryMock.Object);

            // Act
            var result = await repository.GetFilmById(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Title, Is.EqualTo(expectedFilm.Title));
        }
    }
}