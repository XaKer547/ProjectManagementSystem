using ProjectManagementSystem.Domain.ProjectStages;
using SharedKernel;

namespace ProjectManagementSystem.Domain.ProjectStageAnswers;

public sealed class ProjectStageAnswer : Entity<ProjectStageAnswerId>
{
    private ProjectStageAnswer()
    {
        Id = new ProjectStageAnswerId();
        AdditionalResponseFiles = [];
    }

    public PinnedFile Answer { get; private set; }
    public PinnedFile[]? AdditionalResponseFiles { get; private set; }
    public string? Remark { get; private set; }
    public bool Returned { get; private set; }

    public static ProjectStageAnswer Create(PinnedFile file)
    {
        var answer = new ProjectStageAnswer()
        {
            Answer = file,
        };

        return answer;
    }

    public void Return(string? remark, PinnedFile[]? additionalFiles)
    {
        Remark = remark;

        AdditionalResponseFiles = additionalFiles;

        Returned = true;
    }
}