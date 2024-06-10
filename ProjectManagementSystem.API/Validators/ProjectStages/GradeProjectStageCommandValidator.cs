using FluentValidation;
using ProjectManagementSystem.Infrastucture.Helpers;
using ProjectManagementSystem.Infrastucture.Validators.Models;
using ProjectManagementSystem.Application.Commands.ProjectStages;
using ProjectManagementSystem.Infrastucture.Data;

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