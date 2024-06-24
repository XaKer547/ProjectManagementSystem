using ProjectManagementSystem.Domain.ProjectWorks;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.API.Validators.ProjectWorks;

public class ProjectWorkExistsValidator(ProjectManagementSystemDbContext context) : EntityExistsValidator<ProjectWorkId, ProjectWork>(context)
{

}
