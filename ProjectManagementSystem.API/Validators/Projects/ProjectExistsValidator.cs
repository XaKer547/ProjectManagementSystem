using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.Infrastucture.Validators.Projects;

public class ProjectExistsValidator(ProjectManagementSystemDbContext context) : EntityExistsValidator<ProjectId, Project>(context)
{
}