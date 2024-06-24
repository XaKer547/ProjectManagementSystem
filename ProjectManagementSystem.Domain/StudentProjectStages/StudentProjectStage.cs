using ProjectManagementSystem.Domain.ProjectStageAnswers;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.Students;
using SharedKernel;

namespace ProjectManagementSystem.Domain.StudentProjectStages;

public class StudentProjectStage : Entity<StudentProjectStageId>
{
    private StudentProjectStage(ProjectStage stage, Student student)
    {
        Id = new StudentProjectStageId();
        Stage = stage;
        Student = student;
        Answers = [];
    }
    private StudentProjectStage()
    { }

    public ProjectStage Stage { get; private set; }
    public Student Student { get; private set; }
    public int? Mark { get; private set; }
    public List<ProjectStageAnswer> Answers { get; private set; }

    public static StudentProjectStage Create(ProjectStage stage, Student student)
    {
        return new StudentProjectStage(stage, student);
    }
    public void Graduate(int mark)
    {
        Mark = mark;
    }
}