using FluentValidation;
using ProjectManagementSystem.Application.Commands.Projects;
using ProjectManagementSystem.Infrastucture.Data;
using ProjectManagementSystem.API.Helpers;

namespace ProjectManagementSystem.API.Validators.Projects;

public class CompleteProjectCommandValidator : AbstractValidator<CompleteProjectCommand>
{
    public CompleteProjectCommandValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.ProjectId)
            .Exists(context);
    }
}
