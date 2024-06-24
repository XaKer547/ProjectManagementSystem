using ProjectManagementSystem.API.Validators;
using ProjectManagementSystem.Domain.Students;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.API.Validators.Students;

public class StudentExistsValidator(ProjectManagementSystemDbContext context) : EntityExistsValidator<StudentId, Student>(context)
{

}
