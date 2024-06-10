namespace ProjectManagementSystem.Domain.ProjectStages;

public class PinnedFile
{
    private PinnedFile(string projectName, string projectStageName, string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        ProjectName = projectName;
        ProjectStageName = projectStageName;
    }
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string ProjectName { get; private set; }
    public string ProjectStageName { get; private set; }
    public string FilePath => Path.Combine(ProjectName, ProjectStageName, Id.ToString());

    public static PinnedFile Create(string projectName, string projectStageName, string name)
    {
        return new PinnedFile(name, projectName, projectStageName);
    }
}