using FluentValidation;
using ProjectManagementSystem.Infrastucture.Helpers;
using ProjectManagementSystem.Application.Queries.ProjectStages;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.Infrastucture.Validators.ProjectStages;

public class GetProjectStageQueryValidator : AbstractValidator<GetProjectStageQuery>
{
    public GetProjectStageQueryValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.ProjectId)
            .Exists(context);

        RuleFor(x => x.ProjectStageId)
            .Exists(context);
    }
}
