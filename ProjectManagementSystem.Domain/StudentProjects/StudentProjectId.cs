using SharedKernel;

namespace ProjectManagementSystem.Domain.StudentProjects;

public class StudentProjectId : EntityId
{
    public StudentProjectId() : base() { }
    public StudentProjectId(Guid id) : base(id) { }
}
