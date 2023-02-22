using MockingDataDemo.Models;

namespace MockingDataDemo.Services;

public class PersonService
{
    private readonly List<Person> _persons = new();

    public void AddPerson(Person person)
    {
        _persons.Add(person);
    }

    public void DeletePerson(Guid id)
    {
        var person = GetPersonById(id);


        if (person != null)
        {
            _persons.Remove(person);
        }
    }

    public List<Person> GetPersons() 
    { 
        return _persons; 
    }

    public Person? GetPersonById(Guid id)
    {
        return _persons.FirstOrDefault(x => x.Id == id);
    }

    public int GetPersonCount() 
    { 
        return _persons.Count; 
    }
}
