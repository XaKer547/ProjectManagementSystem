using ProjectManagementSystem.Infrastucture.Helpers;
using ProjectManagementSystem.Application.Queries.Groups;
using FluentValidation;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.Infrastucture.Validators.Grops;

public class GetGroupQueryValidator : AbstractValidator<GetGroupQuery>
{
    public GetGroupQueryValidator(ProjectManagementSystemDbContext context)
    {
        When(x => x.GroupId is not null, () =>
        {
            RuleFor(x => x.GroupId)
                .Exists(context);
        });
    }
}