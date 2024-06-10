using ProjectManagementSystem.Domain.Projects;
using SharedKernel;

namespace ProjectManagementSystem.Domain.ProjectStages;

public sealed class ProjectStage : Entity<ProjectStageId>
{
    private ProjectStage(string name, string description, DateTime deadline, PinnedFile[]? pinnedFiles, Project project)
    {
        Id = new ProjectStageId();
        Name = name;
        Description = description;
        Deadline = deadline;
        PinnedFiles = pinnedFiles;
        Project = project;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime Deadline { get; private set; }
    public PinnedFile[]? PinnedFiles { get; private set; }
    public Project Project { get; private set; }

    public static ProjectStage Create(string name, string description, DateTime deadline, PinnedFile[]? pinnedFiles, Project project)
    {
        return new ProjectStage(name, description, deadline, pinnedFiles, project);
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
}