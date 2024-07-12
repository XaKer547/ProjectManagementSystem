using FluentValidation;
using ProjectManagementSystem.Application.Commands.ProjectStages;
using ProjectManagementSystem.Infrastucture.Data;
using ProjectManagementSystem.API.Helpers;

namespace ProjectManagementSystem.API.Validators.ProjectStages;

public class UpdateProjectStageCommandValidator : AbstractValidator<UpdateProjectStageCommand>
{
    public UpdateProjectStageCommandValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.ProjectId)
            .Exists(context);

        RuleFor(x => x.ProjectStageId)
            .Exists(context);
    }
}