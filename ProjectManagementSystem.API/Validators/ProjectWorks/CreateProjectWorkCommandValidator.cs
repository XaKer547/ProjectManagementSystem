using FluentValidation;
using ProjectManagementSystem.API.Helpers;
using ProjectManagementSystem.Application.Commands.ProjectWorks;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.API.Validators.ProjectWorks;

public class CreateProjectWorkCommandValidator : AbstractValidator<CreateProjectWorkCommand>
{
    public CreateProjectWorkCommandValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.ProjectId)
            .Exists(context);

        RuleFor(x => x.StudentId)
            .Exists(context);

        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.SubjectArea)
            .NotEmpty();
    }
}