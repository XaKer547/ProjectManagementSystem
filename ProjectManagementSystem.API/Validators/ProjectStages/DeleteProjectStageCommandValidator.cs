using FluentValidation;
using ProjectManagementSystem.API.Helpers;
using ProjectManagementSystem.API.Validators.Models;
using ProjectManagementSystem.Application.Commands.ProjectStages;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.API.Validators.ProjectStages;

public class DeleteProjectStageCommandValidator : AbstractValidator<DeleteProjectStageCommand>
{
    public DeleteProjectStageCommandValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.ProjectId)
            .Exists(context);

        RuleFor(x => x.ProjectStageId)
            .Exists(context);

        RuleFor(x => new ProjectStageBelongsToProjectDTO()
        {
            ProjectStageId = x.ProjectStageId,
            ProjectId = x.ProjectId,
        })
            .BelongsToProject(context);
    }
}
