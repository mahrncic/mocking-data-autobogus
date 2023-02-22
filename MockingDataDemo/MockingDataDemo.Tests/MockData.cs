using MockingDataDemo.Models;

namespace MockingDataDemo.Tests;
public static class MockData
{
    public static List<Person> Persons 
    {
        get
        {
            return new List<Person>()
            {
                JohnDoe,
                MickeyMouse,
                TestUser,
            };
        }
    }

    public static Person JohnDoe = new()
    {
        Id = Guid.NewGuid(),
        FirstName = "John",
        LastName = "Doe",
        Address = "123 Main St",
        DateOfBirth = new DateTime(1995, 1, 1),
        Email = "johndoe@mail.com",
    };

    public static Person MickeyMouse = new()
    {
        Id = Guid.NewGuid(),
        FirstName = "Mickey",
        LastName = "Mouse",
        Address = "456 Mickey Street",
        DateOfBirth = new DateTime(1997, 2, 2),
        Email = "mickey@example.com",
    };

    public static Person TestUser = new()
    {
        Id = Guid.NewGuid(),
        FirstName = "Test",
        LastName = "User",
        Address = "789 Test St",
        DateOfBirth = new DateTime(1990, 3, 3),
        Email = "testuser@gmail.com",
    };
}
