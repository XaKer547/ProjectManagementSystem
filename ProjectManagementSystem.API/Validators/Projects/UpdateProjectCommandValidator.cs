using FluentValidation;
using ProjectManagementSystem.API.Helpers;
using ProjectManagementSystem.Application.Commands.Projects;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.API.Validators.Projects;

public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
{
    public UpdateProjectCommandValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.ProjectId)
            .Exists(context);

        RuleFor(x => x.ProjectType)
            .IsInEnum();

        When(x => x.Deadline != null, () =>
        {
            RuleFor(x => (DateTime)x.Deadline)
            .NotEarlierThanNow();
        });

        When(x => x.DisciplineId != null, () =>
        {
            RuleFor(x => x.DisciplineId)
            .Exists(context);
        });

        When(x => x.GroupId != null, () =>
        {
            RuleFor(x => x.GroupId)
            .Exists(context);
        });
    }
}