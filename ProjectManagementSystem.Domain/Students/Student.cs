using ProjectManagementSystem.Domain.Groups;
using SharedKernel;

namespace ProjectManagementSystem.Domain.Students;

public sealed class Student : Entity<StudentId>
{
    private Student()
    { }

    public string FirstName { get; private set; }
    public string MiddleName { get; private set; }
    public string LastName { get; private set; }
    public bool Graduated { get; private set; }
    public Group Group { get; private set; }

    public static Student Create(StudentId studentId, string firstName, string middleName, string lastName, Group group)
    {
        var student = new Student()
        {
            Id = studentId,
            FirstName = firstName,
            MiddleName = middleName,
            LastName = lastName,
            Graduated = false,
            Group = group
        };

        return student;
    }

    public void Update(string firstName, string middleName, string lastName, Group group)
    {
        FirstName = firstName;

        MiddleName = middleName;

        LastName = lastName;

        Group = group;
    }

    public void Delete()
    {
        Deleted = true;
    }
}