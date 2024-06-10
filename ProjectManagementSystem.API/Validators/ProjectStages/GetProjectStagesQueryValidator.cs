using FluentValidation;
using ProjectManagementSystem.Infrastucture.Helpers;
using ProjectManagementSystem.Application.Queries.ProjectStages;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.Infrastucture.Validators.ProjectStages;

public class GetProjectStagesQueryValidator : AbstractValidator<GetProjectStagesQuery>
{
    public GetProjectStagesQueryValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.ProjectId)
            .Exists(context);
    }
}
