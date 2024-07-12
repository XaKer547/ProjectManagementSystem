using FluentValidation;
using ProjectManagementSystem.API.Helpers;
using ProjectManagementSystem.Application.Commands.ProjectWorks;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.API.Validators.ProjectWorks;

public class UpdateProjectWorkCommandValidator : AbstractValidator<UpdateProjectWorkCommand>
{
    public UpdateProjectWorkCommandValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.ProjectId)
            .Exists(context);

        RuleFor(x => x.StudentId)
            .Exists(context);
    }
}