using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.Infrastucture.Validators.ProjectStages;

public class ProjectStageExistsValidator(ProjectManagementSystemDbContext context) : EntityExistsValidator<ProjectStageId, ProjectStage>(context)
{
}