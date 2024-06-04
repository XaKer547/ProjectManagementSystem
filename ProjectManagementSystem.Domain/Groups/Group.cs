using SharedKernel;

namespace ProjectManagementSystem.Domain.Groups;

public sealed class Group : Entity<GroupId>
{
    private Group() { }
    public string Name { get; private set; }

    public static Group Create(GroupId groupId, string name)
    {
        var group = new Group()
        {
            Id = groupId,
            Name = name
        };

        return group;
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