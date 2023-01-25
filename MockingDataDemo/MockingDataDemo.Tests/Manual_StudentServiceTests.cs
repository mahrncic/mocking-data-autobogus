using FluentAssertions;
using MockingDataDemo.Models;
using MockingDataDemo.Services;

namespace MockingDataDemo.Tests;
public class Manual_StudentServiceTests
{
    private readonly StudentService _service = new();

    [Fact]
    public void AddStudent_ShouldAddStudentToList()
    {
        // Arrange
        var student = MockData.JohnDoe;

        // Act
        _service.AddStudent(student);

        // Assert
        _service.GetStudents().Should().Contain(student);
    }

    [Fact]
    public void DeleteStudent_ShouldRemoveStudentFromList()
    {
        // Arrange
        var student = MockData.JaneSmith;
        _service.AddStudent(student);

        // Act
        _service.DeleteStudent(student.Id);

        // Assert
        _service.GetStudents().Should().NotContain(student);
    }

    [Fact]
    public void GetStudents_ShouldReturnAllAddedStudents()
    {
        // Arrange
        var students = new List<Student> { MockData.JohnDoe, MockData.JaneSmith, MockData.BobJohnson };
        foreach (var student in students)
        {
            _service.AddStudent(student);
        }

        // Act
        var result = _service.GetStudents();

        // Assert
        result.Should().BeEquivalentTo(students);
    }

    [Fact]
    public void GetStudentById_ShouldReturnCorrectStudent()
    {
        // Arrange
        var students = new List<Student> { MockData.JohnDoe, MockData.JaneSmith, MockData.BobJohnson };
        foreach (var student in students)
        {
            _service.AddStudent(student);
        }

        // Act
        var result = _service.GetStudentById(MockData.JaneSmith.Id);

        // Assert
        result.Should().BeEquivalentTo(MockData.JaneSmith);
    }

    [Fact]
    public void GetStudentById_ShouldReturnNullForInvalidId()
    {
        // Arrange
        var students = new List<Student> { MockData.JohnDoe, MockData.JaneSmith, MockData.BobJohnson };
        foreach (var student in students)
        {
            _service.AddStudent(student);
        }

        // Act
        var result = _service.GetStudentById(Guid.NewGuid());

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public void GetStudentCount_ShouldReturnCorrectCount()
    {
        // Arrange
        var students = new List<Student> { MockData.JohnDoe, MockData.JaneSmith, MockData.BobJohnson };
        foreach (var student in students)
        {
            _service.AddStudent(student);
        }

        // Act
        var result = _service.GetStudentCount();

        // Assert
        result.Should().Be(3);
    }
}
