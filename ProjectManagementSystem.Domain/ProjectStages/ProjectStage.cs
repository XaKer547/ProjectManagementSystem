using ProjectManagementSystem.Domain.Projects;
using SharedKernel;

namespace ProjectManagementSystem.Domain.ProjectStages;

public sealed class ProjectStage : Entity<ProjectStageId>
{
    private ProjectStage(string name, string description, DateTime deadline, PinnedFile[]? pinnedFiles)
    {
        Id = new ProjectStageId();
        Name = name;
        Description = description;
        Deadline = deadline;
        PinnedFiles = pinnedFiles;
    }

    private ProjectStage()
    { }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime Deadline { get; private set; }
    public Project Project { get; private set; }
    public PinnedFile[]? PinnedFiles { get; private set; }

    public static ProjectStage Create(string name, string description, DateTime deadline, PinnedFile[]? pinnedFiles)
    {
        return new ProjectStage(name, description, deadline, pinnedFiles);
    }
    public void Update(string name, string description, DateTime deadline, PinnedFile[] pinnedFiles)
    {
        Name = name;
        Description = description;
        Deadline = deadline;
        PinnedFiles = pinnedFiles;
    }
    public void Delete()
    {
        Deleted = true;
    }
    public void UpdatePinnedFiles(PinnedFile[] pinnedFiles)
    {
        PinnedFiles = pinnedFiles;
    }
}