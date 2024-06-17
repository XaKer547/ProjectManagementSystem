using FluentValidation;
using ProjectManagementSystem.Infrastucture.Helpers;
using ProjectManagementSystem.Application.Commands.Projects;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.Infrastucture.Validators.Projects;

public class GradeProjectCommandValidator : AbstractValidator<GradeProjectCommand>
{
    public GradeProjectCommandValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.ProjectId)
            .Exists(context);

        RuleFor(x => x.StudentId)
            .Exists(context);

        RuleFor(x => x.Grade)
            .InclusiveBetween(2, 5);
    }
}