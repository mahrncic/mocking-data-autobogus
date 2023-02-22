using Microsoft.AspNetCore.Mvc;
using MockingDataDemo.Models;
using MockingDataDemo.Services;

namespace MockingDataDemo.Controllers;
[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly PersonService _personService;

    public PersonController(
        PersonService personService)
    {
        _personService = personService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var persons = _personService.GetPersons();

        return Ok(persons);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var person = _personService.GetPersonById(id);

        return Ok(person);
    }

    [HttpPost]
    public IActionResult AddPerson(Person person)
    {
        _personService.AddPerson(person);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePerson(Guid id)
    {
        _personService.DeletePerson(id);

        return NoContent();
    }

    [HttpGet("count")]
    public IActionResult GetPersonCount() 
    {
        var count = _personService.GetPersonCount();

        return Ok(count);
    }
}
