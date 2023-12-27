using Domain.Models;
using Infrastructure.Extension;
using Infrastructure.External;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Moq.Protected;
using System.Text.Json;

namespace CQRSPatternWebAPI.Test.FilmCharactersTests.HttpClientFactoriesTests
{
    [TestFixture]
    public class HttpClientFactoriesTests
    {
        [Test]
        public async Task GetCharacterById_ShouldReturnPerson()
        {
            // Arrange
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            var httpClient = new HttpClient(httpMessageHandlerMock.Object);

            httpClientFactoryMock
    .Setup(factory => factory.CreateClient("people"))
    .Returns(() =>
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://swapi.dev/api/people/");
        return httpClient;
    });

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
            var serializedPerson = JsonSerializer.Serialize(expectedCharacter);
            httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    Content = new StringContent(serializedPerson),
                    StatusCode = System.Net.HttpStatusCode.OK
                });

            var httpClientFactories = new HttpClientFactories(httpClientFactoryMock.Object);

            // Act
            var result = await httpClientFactories.GetCharacterById(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(expectedCharacter.Name));

        }

        [Test]
        public async Task GetFilmById_ShouldReturnFilm()
        {
            // Arrange
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            var httpClient = new HttpClient(httpMessageHandlerMock.Object);

            httpClientFactoryMock
     .Setup(factory => factory.CreateClient("films"))
     .Returns(() =>
     {
         var httpClient = new HttpClient();
         httpClient.BaseAddress = new Uri("https://swapi.dev/api/films/");
         return httpClient;
     });

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
            var serializedFilm = JsonSerializer.Serialize(expectedFilm);
            httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    Content = new StringContent(serializedFilm),
                    StatusCode = System.Net.HttpStatusCode.OK
                });

            var httpClientFactories = new HttpClientFactories(httpClientFactoryMock.Object);

            // Act
            var result = await httpClientFactories.GetFilmById(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Characters.Count, Is.EqualTo(expectedFilm.Characters.Count));
        }

        [Test]
        public void ConfigureHttpClientService_ConfiguresPeopleAndFilmsHttpClientWithRetryPolicy()
        {
            // Arrange
            var services = new ServiceCollection();
            var configuration = new ConfigurationBuilder().Build(); // Mock configuration as needed

            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();

            var httpClient = new HttpClient(httpMessageHandlerMock.Object);
            httpClientFactoryMock.Setup(factory => factory.CreateClient("people")).Returns(httpClient);
            httpClientFactoryMock.Setup(factory => factory.CreateClient("films")).Returns(httpClient);

            services.AddSingleton(httpClientFactoryMock.Object);            

            // Act
            HttpClientCollectionExtension.ConfigureHttpClientService(services, configuration);            
            var peopleHttpClient = httpClientFactoryMock.Object.CreateClient("people");
            var filmsHttpClient = httpClientFactoryMock.Object.CreateClient("films");

            // Assert         
            Assert.That(peopleHttpClient, Is.Not.Null);
            Assert.That(filmsHttpClient, Is.Not.Null);
          
        }
    }
}