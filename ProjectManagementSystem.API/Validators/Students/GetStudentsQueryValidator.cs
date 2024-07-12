using ProjectManagementSystem.Application.Queries.Students;
using FluentValidation;
using ProjectManagementSystem.Infrastucture.Data;
using ProjectManagementSystem.API.Helpers;

namespace ProjectManagementSystem.API.Validators.Students;

public class GetStudentsQueryValidator : AbstractValidator<GetStudentsQuery>
{
    public GetStudentsQueryValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.GroupId)
            .Exists(context);
    }
}
