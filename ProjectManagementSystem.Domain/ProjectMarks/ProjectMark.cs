using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.Students;
using SharedKernel;

namespace ProjectManagementSystem.Domain.ProjectMarks;

public sealed class ProjectMark : Entity<ProjectMarkId>
{
    private ProjectMark(Project project, Student student, int value)
    {
        Id = new ProjectMarkId();
        Project = project;
        Student = student;
        Value = value;
    }

    public Project Project { get; private set; }
    public Student Student { get; private set; }
    public int Value { get; private set; }

    public static ProjectMark Create(Project project, Student student, int grade)
    {
        return new ProjectMark(project, student, grade);
    }
}