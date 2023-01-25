using AutoBogus;
using FluentAssertions;
using MockingDataDemo.Models;
using MockingDataDemo.Services;

namespace MockingDataDemo.Tests;

public class StudentServiceTests
{
    private readonly StudentService _service = new StudentService();
    private readonly AutoFaker<Student> _faker = new AutoFaker<Student>();

    [Fact]
    public void AddStudent_ShouldAddStudentToList()
    {
        // Arrange
        var student = _faker.Generate();

        // Act
        _service.AddStudent(student);

        // Assert
        _service.GetStudents().Should().Contain(student);
    }

    [Fact]
    public void DeleteStudent_ShouldRemoveStudentFromList()
    {
        // Arrange
        var student = _faker.Generate();
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
        var students = _faker.Generate(3);
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
        var students = _faker.Generate(3);
        foreach (var student in students)
        {
            _service.AddStudent(student);
        }

        // Act
        var result = _service.GetStudentById(students[1].Id);

        // Assert
        result.Should().BeEquivalentTo(students[1]);
    }

    [Fact]
    public void GetStudentById_ShouldReturnNullForInvalidId()
    {
        // Arrange
        var students = _faker.Generate(3);
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
        var students = _faker.Generate(3);
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