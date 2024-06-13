using ProjectManagementSystem.Domain.Groups;
using SharedKernel;

namespace ProjectManagementSystem.Domain.Students;

public sealed class Student : Entity<StudentId>
{
    private Student(StudentId id,
                    string firstName,
                    string middleName,
                    string lastName,
                    Group group)
    {
        Id = id;
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        Group = group;
    }
    private Student()
    { }

    public string FirstName { get; private set; }
    public string MiddleName { get; private set; }
    public string LastName { get; private set; }
    public bool Graduated { get; private set; }
    public Group Group { get; private set; }

    public static Student Create(StudentId id, string firstName, string middleName, string lastName, Group group)
    {
        return new Student(id, firstName, middleName, lastName, group);
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