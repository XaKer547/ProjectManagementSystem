using FluentValidation;
using ProjectManagementSystem.Application.Queries.Students;
using ProjectManagementSystem.Infrastucture.Data;
using ProjectManagementSystem.Infrastucture.Helpers;

namespace ProjectManagementSystem.Infrastucture.Validators.Students;

public class GetStudentQueryValidator : AbstractValidator<GetStudentQuery>
{
    public GetStudentQueryValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.StudentId)
            .Exists(context);
    }
}
