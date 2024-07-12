using ProjectManagementSystem.API.Validators;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.API.Validators.Projects;

public class ProjectExistsValidator(ProjectManagementSystemDbContext context) : EntityExistsValidator<ProjectId, Project>(context)
{
}