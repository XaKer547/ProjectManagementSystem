using FluentValidation;
using ProjectManagementSystem.API.Helpers;
using ProjectManagementSystem.API.Validators.Models;
using ProjectManagementSystem.Application.Queries.ProjectStages;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.API.Validators.ProjectStages;

public class GetProjectStageQueryValidator : AbstractValidator<GetProjectStageQuery>
{
    public GetProjectStageQueryValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => new StudentProjectStageBelongsToProjectDTO()
        {
            ProjectId = x.ProjectId,
            ProjectStageId = x.ProjectStageId
        })
            .BelongsToProject(context);
    }
}