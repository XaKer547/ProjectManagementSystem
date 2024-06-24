using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.StudentProjectStages;
using ProjectManagementSystem.Domain.Students;
using SharedKernel;

namespace ProjectManagementSystem.Domain.StudentProjects;

public class StudentProject : Entity<StudentProjectId>
{
    private StudentProject(Project project, Student student, string name, string subjectArea)
    {
        Id = new StudentProjectId();
        Project = project;
        Name = name;
        SubjectArea = subjectArea;
        Student = student;
        Stages = [];
    }
    private StudentProject()
    { }

    public Project Project { get; private set; }
    public Student Student { get; private set; }
    public string Name { get; private set; }
    public string SubjectArea { get; private set; }
    public int? Mark { get; private set; }
    public List<StudentProjectStage> Stages { get; private set; }

    public static StudentProject Create(Project project, Student student, string name, string subjectArea)
    {
        return new StudentProject(project, student, name, subjectArea);
    }
    public void Graduate(int mark)
    {
        Mark = mark;
    }
    public void Delete()
    {
        Deleted = true;
    }
}