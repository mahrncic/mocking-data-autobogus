 using Microsoft.AspNetCore.Mvc;
using MockingDataDemo.Models;
using MockingDataDemo.Services;

namespace MockingDataDemo.Controllers;
[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly ILogger<StudentsController> _logger;
    private readonly StudentService _studentService;

    public StudentsController(
        ILogger<StudentsController> logger,
        StudentService studentService)
    {
        _logger = logger;
        _studentService = studentService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var students = _studentService.GetStudents();

        return Ok(students);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var student = _studentService.GetStudentById(id);

        return Ok(student);
    }

    [HttpPost]
    public IActionResult AddStudent(Student student)
    {
        _studentService.AddStudent(student);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(Guid id)
    {
        _studentService.DeleteStudent(id);

        return NoContent();
    }

    [HttpGet("count")]
    public IActionResult GetStudentCount() 
    {
        var count = _studentService.GetStudentCount();

        return Ok(count);
    }
}
