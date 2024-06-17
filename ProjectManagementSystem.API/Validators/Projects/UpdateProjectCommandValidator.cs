using FluentValidation;
using ProjectManagementSystem.Application.Commands.Projects;
using ProjectManagementSystem.Infrastucture.Data;
using ProjectManagementSystem.Infrastucture.Helpers;

namespace ProjectManagementSystem.Infrastucture.Validators.Projects;

public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
{
    public UpdateProjectCommandValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.ProjectId)
            .Exists(context);

        RuleFor(x => x.ProjectType)
            .IsInEnum();

        When(x => x.DisciplineId.Value != Guid.Empty, () =>
        {
            RuleFor(x => x.DisciplineId)
            .Exists(context);
        });

        When(x => x.GroupId.Value != Guid.Empty, () =>
        {
            RuleFor(x => x.DisciplineId)
            .Exists(context);
        });
    }
}
