using ProjectManagementSystem.Infrastucture.Helpers;
using ProjectManagementSystem.Application.Queries.Students;
using FluentValidation;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.Infrastucture.Validators.Students;

public class GetStudentsQueryValidator : AbstractValidator<GetStudentsQuery>
{
    public GetStudentsQueryValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.GroupId)
            .Exists(context);
    }
}
