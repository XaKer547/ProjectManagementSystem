using ProjectManagementSystem.Domain.ProjectStages;
using SharedKernel;

namespace ProjectManagementSystem.Domain.ProjectStageAnswers;

public sealed class ProjectStageAnswer : Entity<ProjectStageAnswerId>
{
    private ProjectStageAnswer(PinnedFile answer)
    {
        Id = new ProjectStageAnswerId();
        Answer = answer;
    }

    public PinnedFile Answer { get; private set; }
    public PinnedFile? AdditionalResponseFiles { get; private set; }
    public string? Remark { get; private set; }
    public bool Returned { get; private set; }

    public static ProjectStageAnswer Create(PinnedFile answer)
    {
        return new ProjectStageAnswer(answer);
    }
    public void Return(string? remark, PinnedFile? additionalFiles)
    {
        Remark = remark;

        AdditionalResponseFiles = additionalFiles;

        Returned = true;
    }
}