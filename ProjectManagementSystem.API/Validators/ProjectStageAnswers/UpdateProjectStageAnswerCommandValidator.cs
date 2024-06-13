using FluentValidation;
using ProjectManagementSystem.Application.Commands.ProjectStageAnswers;
using ProjectManagementSystem.Infrastucture.Data;
using ProjectManagementSystem.Infrastucture.Helpers;
using ProjectManagementSystem.Infrastucture.Validators.Models;

namespace ProjectManagementSystem.API.Validators.ProjectStageAnswers;

public class UpdateProjectStageAnswerCommandValidator : AbstractValidator<UpdateProjectStageAnswerCommand>
{
    public UpdateProjectStageAnswerCommandValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => new ProjectStageBelongsToProjectDTO()
        {
            ProjectId = x.ProjectId,
            ProjectStageId = x.ProjectStageId,
        }).BelongsToProject(context);

        RuleFor(x => x.PinnedFile)
            .NotNull();
    }
}