using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.StudentProjectStages;
using ProjectManagementSystem.Domain.Students;
using SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagementSystem.Domain.ProjectWorks;

public class ProjectWork : Entity<ProjectWorkId>
{
    private ProjectWork(Project project, Student student, string name, string subjectArea)
    {
        Id = new ProjectWorkId();
        Project = project;
        Name = name;
        SubjectArea = subjectArea;
        Student = student;
        Stages = [];
    }
    private ProjectWork()
    { }

    public Project Project { get; private set; }
    public Student Student { get; private set; }
    public string Name { get; private set; }
    public string SubjectArea { get; private set; }
    public int? Grade { get; private set; }
    public List<StudentProjectStage> Stages { get; private set; }

    public static ProjectWork Create(Project project, Student student, string name, string subjectArea)
    {
        return new ProjectWork(project, student, name, subjectArea);
    }
    public void Update(string name, string subjectArea)
    {
        Name = name;
        SubjectArea = subjectArea;
    }
    public void Graduate(int mark)
    {
        Grade = mark;
    }
    public void Delete()
    {
        Deleted = true;
    }
}