using FluentValidation;
using ProjectManagementSystem.API.Helpers;
using ProjectManagementSystem.API.Validators.Models;
using ProjectManagementSystem.Application.Commands.ProjectStages;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.API.Validators.ProjectStages;

public class GradeProjectStageCommandValidator : AbstractValidator<GradeProjectStageCommand>
{
    public GradeProjectStageCommandValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.ProjectId)
            .Exists(context);

        RuleFor(x => new StudentProjectStageBelongsToProjectDTO()
        {
            ProjectStageId = x.ProjectStageId,
            ProjectId = x.ProjectId,
        })
            .BelongsToProject(context);

        RuleFor(x => x.Grade)
            .InclusiveBetween(2, 5);
    }
}