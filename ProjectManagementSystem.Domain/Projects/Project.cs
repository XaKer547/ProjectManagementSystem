using ProjectManagementSystem.Domain.Disciplines;
using ProjectManagementSystem.Domain.Groups;
using ProjectManagementSystem.Domain.Projects.Events;
using ProjectManagementSystem.Domain.ProjectStages;
using SharedKernel;
using SharedKernel.DTOs.ProjectType;

namespace ProjectManagementSystem.Domain.Projects;

public sealed class Project : Entity<ProjectId>
{
    private Project(ProjectTypes type,
                    Discipline discipline,
                    Group group,
                    DateTime deadline)
    {
        Id = new ProjectId();
        Type = type;
        Discipline = discipline;
        Group = group;
        Deadline = deadline;
    }

    private Project()
    { }

    public ProjectTypes Type { get; private set; }
    public Discipline Discipline { get; private set; }
    public Group Group { get; private set; }
    public DateTime Deadline { get; private set; }
    public bool Completed { get; private set; } = false;
    public List<ProjectStage> Stages { get; private set; }

    public static Project Create(ProjectTypes type, Discipline discipline, Group group, DateTime deadline)
    {
        var project = new Project(type, discipline, group, deadline);

        var projectCreatedEvent = new ProjectCreatedEvent()
        {
            Project = project,
        };

        project.AddEvent(projectCreatedEvent);

        return project;
    }
    public void Update(ProjectTypes type, Discipline discipline, Group group, DateTime deadline)
    {
        Type = type;
        Discipline = discipline;
        Group = group;
        Deadline = deadline;
    }
    public void Delete()
    {
        Deleted = true;
    }
    public void Complete()
    {
        Completed = true;
    }
}