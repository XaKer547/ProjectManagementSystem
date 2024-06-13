using FluentValidation;
using ProjectManagementSystem.Infrastucture.Helpers;
using ProjectManagementSystem.Application.Queries.ProjectStages;
using ProjectManagementSystem.Infrastucture.Data;
using ProjectManagementSystem.Infrastucture.Validators.Models;

namespace ProjectManagementSystem.Infrastucture.Validators.ProjectStages;

public class GetProjectStageQueryValidator : AbstractValidator<GetProjectStageQuery>
{
    public GetProjectStageQueryValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => new ProjectStageBelongsToProjectDTO()
        {
            ProjectId = x.ProjectId,
            ProjectStageId = x.ProjectStageId
        })
            .BelongsToProject(context);
    }
}