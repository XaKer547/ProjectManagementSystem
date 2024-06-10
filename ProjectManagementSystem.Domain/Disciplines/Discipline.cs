using SharedKernel;

namespace ProjectManagementSystem.Domain.Disciplines;

public sealed class Discipline : Entity<DisciplineId>
{
    private Discipline(DisciplineId id, string name)
    {
        Id = id;
        Name = name;
    }
    public string Name { get; private set; }

    public static Discipline Create(DisciplineId id, string name)
    {
        return new Discipline(id, name);
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