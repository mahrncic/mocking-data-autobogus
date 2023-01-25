using MockingDataDemo.Models;

namespace MockingDataDemo.Tests;
public static class MockData
{
    public static List<Student> Students = new()
    {
        JohnDoe!,
        MickeyMouse!,
        TestUser!,
    };

    public static Student JohnDoe = new()
    {
        Id = Guid.NewGuid(),
        FirstName = "John",
        LastName = "Doe",
        Address = "123 Main St",
        DateOfBirth = new DateTime(1995, 1, 1),
        Email = "johndoe@mail.com"
    };

    public static Student MickeyMouse = new()
    {
        Id = Guid.NewGuid(),
        FirstName = "Mickey",
        LastName = "Mouse",
        Address = "456 Mickey Street",
        DateOfBirth = new DateTime(1997, 2, 2),
        Email = "mickey@example.com"
    };

    public static Student TestUser = new()
    {
        Id = Guid.NewGuid(),
        FirstName = "Test",
        LastName = "User",
        Address = "789 Test St",
        DateOfBirth = new DateTime(1990, 3, 3),
        Email = "testuser@gmail.com"
    };
}
