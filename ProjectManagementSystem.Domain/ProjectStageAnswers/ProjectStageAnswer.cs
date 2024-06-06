using ProjectManagementSystem.Domain.StudentProjectStages;
using SharedKernel;

namespace ProjectManagementSystem.Domain.ProjectStageAnswers;

public sealed class ProjectStageAnswer : Entity<ProjectStageAnswerId>
{
    private ProjectStageAnswer()
    {
        Id = new ProjectStageAnswerId();
    }

    public StudentProjectStage Student { get; private set; }
    public List<string> Files { get; private set; }
    public bool Returned { get; private set; }
    public string? Remark { get; private set; }
}