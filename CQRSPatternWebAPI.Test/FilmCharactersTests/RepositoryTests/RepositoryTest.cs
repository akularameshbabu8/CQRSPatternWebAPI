using Domain.Models;
using Infrastructure;
using Moq;

namespace CQRSPatternWebAPI.Test.FilmCharactersTests.RepositoryTests
{
    [TestFixture]
    public  class RepositoryTest
    {
       
        private Mock<IDataService> _dataService;
        

        [SetUp]
        public void SetUp()
        {
            
            _dataService = new Mock<IDataService>();

        }
        [Test]
        public void GetById_ReturnsEntity_WhenDataServiceReturnsData()
        {
            // Arrange

            _dataService.Setup(ds => ds.GetDataResult(It.IsAny<string>()))
                           .Returns("{\"name\":\"Luke Skywalker\",\"height\":\"172\",\"mass\":\"77\",\"hair_color\":\"blond\",\"skin_color\":\"fair\",\"eye_color\":\"blue\",\"birth_year\":\"19BBY\",\"gender\":\"male\",\"homeworld\":\"https://swapi.dev/api/planets/1/\",\"films\":[\"https://swapi.dev/api/films/1/\",\"https://swapi.dev/api/films/2/\",\"https://swapi.dev/api/films/3/\",\"https://swapi.dev/api/films/6/\"],\"species\":[],\"vehicles\":[\"https://swapi.dev/api/vehicles/14/\",\"https://swapi.dev/api/vehicles/30/\"],\"starships\":[\"https://swapi.dev/api/starships/12/\",\"https://swapi.dev/api/starships/22/\"],\"created\":\"2014-12-09T13:50:51.644000Z\",\"edited\":\"2014-12-20T21:17:56.891000Z\",\"url\":\"https://swapi.dev/api/people/1/\"}");

            var repository = new Repository<Person>(_dataService.Object);

                // Act
                var result = repository.GetById(1);

                // Assert
                Assert.That(result, Is.Not.Null);
                
            }
        }
}
