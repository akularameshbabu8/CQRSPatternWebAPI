using Application.Services;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Moq.Protected;
using System.Text.Json;

namespace CQRSPatternWebAPI.Test.HttpClientServiceTests
{
    [TestFixture]
    public class HttpClientServiceTests
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

            var _iHttpClientService = new HttpClientService(httpClientFactoryMock.Object);

            // Act
            var result = await _iHttpClientService.GetCharacterById(1);

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
                Title = "A New Hope",
                EpisodeId = 4,
                OpeningCrawl = "It is a period of civil war.\r\nRebel spaceships, striking\r\nfrom a hidden base, have won\r\ntheir first victory against\r\nthe evil Galactic Empire.\r\n\r\nDuring the battle, Rebel\r\nspies managed to steal secret\r\nplans to the Empire's\r\nultimate weapon, the DEATH\r\nSTAR, an armored space\r\nstation with enough power\r\nto destroy an entire planet.\r\n\r\nPursued by the Empire's\r\nsinister agents, Princess\r\nLeia races home aboard her\r\nstarship, custodian of the\r\nstolen plans that can save her\r\npeople and restore\r\nfreedom to the galaxy....",
                Director = "George Lucas",
                Producer = "Gary Kurtz, Rick McCallum",
                ReleaseDate = "1977-05-25",
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
                },
                Planets = new List<string> {{"https://swapi.dev/api/planets/1/" },
                    { "https://swapi.dev/api/planets/2/" },
                    { "https://swapi.dev/api/planets/3/" }
                },
                Starships = new List<string> {
                    { "https://swapi.dev/api/starships/2/"},
                    { "https://swapi.dev/api/starships/3/" },
                    { "https://swapi.dev/api/starships/5/" },
                    { "https://swapi.dev/api/starships/9/" },
                    { "https://swapi.dev/api/starships/10/" },
                    { "https://swapi.dev/api/starships/11/" },
                    { "https://swapi.dev/api/starships/12/" },
                     { "https://swapi.dev/api/starships/13/" }
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

            var _iHttpClientService = new HttpClientService(httpClientFactoryMock.Object); ;

            // Act
            var result = await _iHttpClientService.GetFilmById(1);

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