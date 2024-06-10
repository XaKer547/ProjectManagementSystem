using ProjectManagementSystem.Infrastucture.Helpers;
using ProjectManagementSystem.Application.Queries.Students;
using FluentValidation;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.Infrastucture.Validators.Students;

public class GetStudentQueryValidator : AbstractValidator<GetStudentQuery>
{
    public GetStudentQueryValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.StudentId)
            .Exists(context);
    }
}
