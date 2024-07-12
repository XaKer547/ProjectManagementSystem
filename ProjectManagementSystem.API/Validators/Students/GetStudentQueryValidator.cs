using ProjectManagementSystem.Application.Queries.Students;
using FluentValidation;
using ProjectManagementSystem.Infrastucture.Data;
using ProjectManagementSystem.API.Helpers;

namespace ProjectManagementSystem.API.Validators.Students;

public class GetStudentQueryValidator : AbstractValidator<GetStudentQuery>
{
    public GetStudentQueryValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.StudentId)
            .Exists(context);
    }
}
