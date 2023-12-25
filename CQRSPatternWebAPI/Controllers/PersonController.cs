using Application.Queries.Persons.GetById;
using Domain.Models;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    public class PersonController : ControllerBase
    {
        internal readonly IMediator _mediator;
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }
        private readonly IRepository<Person> _peopleRepo = new Repository<Person>();
        



        [HttpGet]
        [Route("/swapi/films/{filmId}/characters/{characterId}")]
        public async Task<IActionResult> GetPersonById(int characterId)
        {

            return Ok(await _mediator.Send(new GetPersonByIdQuery(characterId)));
        }



    }
}
