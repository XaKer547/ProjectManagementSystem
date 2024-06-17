using SharedKernel;

namespace ProjectManagementSystem.Domain.Groups;

public sealed class Group : Entity<GroupId>
{
    private Group(GroupId id, string name)
    {
        Id = id;
        Name = name;
    }
    public string Name { get; private set; }

    public static Group Create(GroupId id, string name)
    {
        return new Group(id, name);
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