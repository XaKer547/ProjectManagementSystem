using FluentValidation;
using ProjectManagementSystem.API.Helpers;
using ProjectManagementSystem.API.Validators.Models;
using ProjectManagementSystem.Application.Commands.ProjectStageAnswers;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.API.Validators.ProjectStageAnswers;

public class ReturnProjectStageAnswerCommandValidator : AbstractValidator<ReturnProjectStageAnswerCommand>
{
    public ReturnProjectStageAnswerCommandValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => new StudentProjectStageBelongsToProjectDTO()
        {
            ProjectId = x.ProjectId,
            ProjectStageId = x.ProjectStageId,
        })
            .BelongsToProject(context);
    }
}
