using FluentValidation;
using ProjectManagementSystem.Infrastucture.Helpers;
using ProjectManagementSystem.Application.Queries.Projects;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.Infrastucture.Validators.Projects;

public class GetProjectQueryValidator : AbstractValidator<GetProjectQuery>
{
    public GetProjectQueryValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.ProjectId)
            .Exists(context);
    }
}
