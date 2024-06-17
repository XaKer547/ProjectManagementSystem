using FluentValidation;
using ProjectManagementSystem.Application.Commands.ProjectStages;
using ProjectManagementSystem.Infrastucture.Data;
using ProjectManagementSystem.Infrastucture.Helpers;
using ProjectManagementSystem.Infrastucture.Validators.Models;

namespace ProjectManagementSystem.Infrastucture.Validators.ProjectStages;

public class GradeProjectStageCommandValidator : AbstractValidator<GradeProjectStageCommand>
{
    public GradeProjectStageCommandValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.ProjectId)
            .Exists(context);

        RuleFor(x => new ProjectStageBelongsToProjectDTO()
        {
            ProjectStageId = x.ProjectStageId,
            ProjectId = x.ProjectId,
        })
            .BelongsToProject(context);

        RuleFor(x => x.Grade)
            .InclusiveBetween(2, 5);
    }
}