using FluentValidation;
using ProjectManagementSystem.Application.Commands.ProjectStages;
using ProjectManagementSystem.Infrastucture.Data;
using ProjectManagementSystem.Infrastucture.Helpers;

namespace ProjectManagementSystem.Infrastucture.Validators.ProjectStages;

public class DeleteProjectStageCommandValidator : AbstractValidator<DeleteProjectStageCommand>
{
    public DeleteProjectStageCommandValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.ProjectId)
            .Exists(context);

        RuleFor(x => x.ProjectStageId)
            .Exists(context);
    }
}
