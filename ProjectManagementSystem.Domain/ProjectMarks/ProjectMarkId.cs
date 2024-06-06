using SharedKernel;

namespace ProjectManagementSystem.Domain.ProjectMarks;

public class ProjectMarkId : EntityId
{
    public ProjectMarkId(Guid id) : base(id) { }
    public ProjectMarkId() : base() { }
}