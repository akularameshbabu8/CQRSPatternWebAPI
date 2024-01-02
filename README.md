About SWAPI 
https://swapi.dev hosts apis serving information on the Start Wars movie franchise. A typical consumer can get 
information on the people, planets, vehicles and films in the Star Wars movie franchise. 
Exercise 
Create a single api end point that consumes the existing SWAPI api, and perform the following transformation. 
For a given film in Star Wars check a character has appeared if yes retrieve the character information. Use any 
version of Microsoft Visual Studio or any editor of your preference. Project should compile, and your api should be 
running under localhost. 
Location of SWAPI film api 
http://swapi.dev/api/films/{id} 
id is the route parameter which is an integer. 
Response of the api - Eg http://swapi.dev/api/films/1 
The film api response has the film details with urls of the characters that appear in the film (field: characters). A 
typical character url is http://swapi.dev/api/people/{id} 
id is the route parameter which is an integer. 
Response of the api - Eg http://swapi.dev/api/people/1
Your api project should have a single endpoint /swapi/films/{filmId}/characters/{characterId}. Calling this api 
should fetch the character information using the http://swapi.dev/api/people/{characterId} endpoint, if the 
character has appeared in http://swapi.dev/api/films/{filmId} 
An example of the expected api response is as follows - 
{
  "name": "Luke Skywalker",
  "birth_year": "19BBY",
  "eye_color": "blue",
  "gender": "male",
  "hair_color": "blond",
  "height": "172",
  "mass": "77",
  "skin_color": "fair",
  "filmsCount": 4,
  "starshipsCount": 2,
  "vehiclesCount": 2
}
The naming convention of your response attributes, endpoint, and any created classes or functions is up to your
discretion. This project should only have 1 api endpoint, but it should be completed with any support libraries you 
feel necessary. Try your best to build the endpoint as if it were going to be deployed to a production environment. 
Include any code comments and documentation you would normally expect to include in a project of this type. 
Your project should have an api documentation. Proper Http status codes should be used on your response. 
Exception handling should be done and a failed request should return a 500 http status code. 
