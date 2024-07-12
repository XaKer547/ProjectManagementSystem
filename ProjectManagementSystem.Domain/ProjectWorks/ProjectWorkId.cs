using SharedKernel;

namespace ProjectManagementSystem.Domain.ProjectWorks;

public class ProjectWorkId : EntityId
{
    public ProjectWorkId() : base() { }
    public ProjectWorkId(Guid id) : base(id) { }
}
