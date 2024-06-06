using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.Students;
using SharedKernel;

namespace ProjectManagementSystem.Domain.ProjectMarks;

public sealed class ProjectMark : Entity<ProjectMarkId>
{
    private ProjectMark()
    {
        Id = new ProjectMarkId();
    }

    public Project Project { get; private set; }
    public Student Student { get; private set; }

    public int Value { get; private set; }

    public static ProjectMark Create(Student student, Project project, int grade)
    {
        var mark = new ProjectMark()
        {
            Student = student,
            Project = project,
            Value = grade,
        };

        return mark;
    }
}