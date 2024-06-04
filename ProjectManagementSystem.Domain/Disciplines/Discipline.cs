using SharedKernel;

namespace ProjectManagementSystem.Domain.Disciplines;

public sealed class Discipline : Entity<DisciplineId>
{
    private Discipline()
    {
    }
    public string Name { get; private set; }

    public static Discipline Create(DisciplineId id, string name)
    {
        var discipline = new Discipline()
        {
            Id = id,
            Name = name
        };

        return discipline;
    }

    public void Delete()
    {
        Deleted = true;
    }

    public void Update(string name)
    {
        Name = name;
    }
}