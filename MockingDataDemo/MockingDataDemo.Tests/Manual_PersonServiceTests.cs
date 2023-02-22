using FluentAssertions;
using MockingDataDemo.Services;

namespace MockingDataDemo.Tests;
public class Manual_PersonServiceTests
{
    private readonly PersonService _service = new();

    [Fact]
    public void AddPerson_ShouldAddPersonToList()
    {
        // Arrange
        var person = MockData.JohnDoe;

        // Act
        _service.AddPerson(person);

        // Assert
        _service.GetPersons().Should().Contain(person);
    }

    [Fact]
    public void DeletePerson_ShouldRemovePersonFromList()
    {
        // Arrange
        var person = MockData.MickeyMouse;
        _service.AddPerson(person);

        // Act
        _service.DeletePerson(person.Id);

        // Assert
        _service.GetPersons().Should().NotContain(person);
    }

    [Fact]
    public void GetPersons_ShouldReturnAllAddedPersons()
    {
        // Arrange
        foreach (var person in MockData.Persons)
        {
            _service.AddPerson(person);
        }

        // Act
        var result = _service.GetPersons();

        // Assert
        result.Should().BeEquivalentTo(MockData.Persons);
    }

    [Fact]
    public void GetPersonById_ShouldReturnCorrectPerson()
    {
        // Arrange
        foreach (var person in MockData.Persons)
        {
            _service.AddPerson(person);
        }

        // Act
        var result = _service.GetPersonById(MockData.MickeyMouse.Id);

        // Assert
        result.Should().BeEquivalentTo(MockData.MickeyMouse);
    }

    [Fact]
    public void GetPersonById_ShouldReturnNullForInvalidId()
    {
        // Arrange
        foreach (var person in MockData.Persons)
        {
            _service.AddPerson(person);
        }

        // Act
        var result = _service.GetPersonById(Guid.NewGuid());

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public void GetPersonCount_ShouldReturnCorrectCount()
    {
        // Arrange
        foreach (var person in MockData.Persons)
        {
            _service.AddPerson(person);
        }

        // Act
        var result = _service.GetPersonCount();

        // Assert
        result.Should().Be(3);
    }
}
