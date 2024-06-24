using FluentValidation;
using ProjectManagementSystem.API.Helpers;
using ProjectManagementSystem.API.Validators.Models;
using ProjectManagementSystem.Application.Commands.ProjectStageAnswers;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.API.Validators.ProjectStageAnswers;

public class CreateProjectStageAnswerCommandValidator : AbstractValidator<CreateProjectStageAnswerCommand>
{
    public CreateProjectStageAnswerCommandValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => new StudentProjectStageBelongsToProjectDTO()
        {
            ProjectId = x.ProjectId,
            ProjectStageId = x.ProjectStageId,
        })
            .BelongsToProject(context);

        RuleFor(x => x.PinnedFile)
            .NotNull();
    }
}
