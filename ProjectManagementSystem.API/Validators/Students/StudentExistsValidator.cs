using ProjectManagementSystem.Domain.Students;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.Infrastucture.Validators.Students;

public class StudentExistsValidator(ProjectManagementSystemDbContext context) : EntityExistsValidator<StudentId, Student>(context)
{

}
