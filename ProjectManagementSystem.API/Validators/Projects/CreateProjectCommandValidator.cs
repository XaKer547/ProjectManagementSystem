using FluentValidation;
using ProjectManagementSystem.Infrastucture.Helpers;
using ProjectManagementSystem.Application.Commands.Projects;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.Infrastucture.Validators.Projects;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.ProjectType)
            .IsInEnum();

        RuleFor(x => x.GroupId)
            .Exists(context);

        RuleFor(x => x.DisciplineId)
            .Exists(context);

        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.SubjectArea)
            .NotEmpty();
    }
}
