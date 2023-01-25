using MockingDataDemo.Models;

namespace MockingDataDemo.Services;

public class StudentService
{
    private readonly List<Student> _students = new();

    public void AddStudent(Student student)
    {
        _students.Add(student);
    }

    public void DeleteStudent(Guid id)
    {
        var student = GetStudentById(id);


        if (student != null)
        {
            _students.Remove(student);
        }
    }

    public List<Student> GetStudents() 
    { 
        return _students; 
    }

    public Student? GetStudentById(Guid id)
    {
        return _students.FirstOrDefault(x => x.Id == id);
    }

    public int GetStudentCount() 
    { 
        return _students.Count; 
    }
}
