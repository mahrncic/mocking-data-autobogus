using AutoBogus;
using FluentAssertions;
using MockingDataDemo.Models;
using MockingDataDemo.Services;

namespace MockingDataDemo.Tests;

public class Autobogus_PersonServiceTests
{
    private readonly PersonService _service = new();
    private readonly AutoFaker<Person> _faker = new();

    [Fact]
    public void AddPerson_ShouldAddPersonToList()
    {
        // Arrange
        var person = _faker.Generate();

        // Act
        _service.AddPerson(person);

        // Assert
        _service.GetPersons().Should().Contain(person);
    }

    [Fact]
    public void DeletePerson_ShouldRemovePersonFromList()
    {
        // Arrange
        var person = _faker.Generate();
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
        var persons = _faker.Generate(3);
        foreach (var person in persons)
        {
            _service.AddPerson(person);
        }

        // Act
        var result = _service.GetPersons();

        // Assert
        result.Should().BeEquivalentTo(persons);
    }

    [Fact]
    public void GetPersonById_ShouldReturnCorrectPerson()
    {
        // Arrange
        var persons = _faker.Generate(3);
        foreach (var person in persons)
        {
            _service.AddPerson(person);
        }

        // Act
        var result = _service.GetPersonById(persons[1].Id);

        // Assert
        result.Should().BeEquivalentTo(persons[1]);
    }

    [Fact]
    public void GetPersonById_ShouldReturnNullForInvalidId()
    {
        // Arrange
        var persons = _faker.Generate(3);
        foreach (var person in persons)
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
        var persons = _faker.Generate(3);
        foreach (var person in persons)
        {
            _service.AddPerson(person);
        }

        // Act
        var result = _service.GetPersonCount();

        // Assert
        result.Should().Be(3);
    }
}