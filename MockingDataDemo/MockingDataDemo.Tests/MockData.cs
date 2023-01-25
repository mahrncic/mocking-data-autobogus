using MockingDataDemo.Models;

namespace MockingDataDemo.Tests;
public static class MockData
{
    public static List<Student> Students = new()
    {
        JohnDoe!,
        JaneSmith!,
        BobJohnson!,
    };

    public static Student JohnDoe = new()
    {
        Id = Guid.NewGuid(),
        FirstName = "John",
        LastName = "Doe",
        Address = "123 Main St",
        DateOfBirth = new DateTime(1995, 1, 1),
        Email = "johndoe@example.com"
    };

    public static Student JaneSmith = new()
    {
        Id = Guid.NewGuid(),
        FirstName = "Jane",
        LastName = "Smith",
        Address = "456 Park Ave",
        DateOfBirth = new DateTime(1997, 2, 2),
        Email = "janesmith@example.com"
    };

    public static Student BobJohnson = new()
    {
        Id = Guid.NewGuid(),
        FirstName = "Bob",
        LastName = "Johnson",
        Address = "789 Elm St",
        DateOfBirth = new DateTime(1990, 3, 3),
        Email = "bobjohnson@example.com"
    };
}
