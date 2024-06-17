using FluentValidation;
using ProjectManagementSystem.Domain.Disciplines;
using ProjectManagementSystem.Domain.Groups;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.Students;
using ProjectManagementSystem.Infrastucture.Data;
using ProjectManagementSystem.Infrastucture.Validators.Disciplines;
using ProjectManagementSystem.Infrastucture.Validators.Grops;
using ProjectManagementSystem.Infrastucture.Validators.Models;
using ProjectManagementSystem.Infrastucture.Validators.Projects;
using ProjectManagementSystem.Infrastucture.Validators.ProjectStages;
using ProjectManagementSystem.Infrastucture.Validators.Students;

namespace ProjectManagementSystem.Infrastucture.Helpers;

public static class AbstractValidatorExtensions
{
    public static IRuleBuilderOptions<T, GroupId> Exists<T>(this IRuleBuilder<T, GroupId> ruleBuilder, ProjectManagementSystemDbContext context)
    {
        return ruleBuilder.SetValidator(new GroupExistsValidator(context));
    }
    public static IRuleBuilderOptions<T, StudentId> Exists<T>(this IRuleBuilder<T, StudentId> ruleBuilder, ProjectManagementSystemDbContext context)
    {
        return ruleBuilder.SetValidator(new StudentExistsValidator(context));
    }
    public static IRuleBuilderOptions<T, DisciplineId> Exists<T>(this IRuleBuilder<T, DisciplineId> ruleBuilder, ProjectManagementSystemDbContext context)
    {
        return ruleBuilder.SetValidator(new DisciplineExistsValidator(context));
    }
    public static IRuleBuilderOptions<T, ProjectId> Exists<T>(this IRuleBuilder<T, ProjectId> ruleBuilder, ProjectManagementSystemDbContext context)
    {
        return ruleBuilder.SetValidator(new ProjectExistsValidator(context));
    }
    public static IRuleBuilderOptions<T, ProjectStageId> Exists<T>(this IRuleBuilder<T, ProjectStageId> ruleBuilder, ProjectManagementSystemDbContext context)
    {
        return ruleBuilder.SetValidator(new ProjectStageExistsValidator(context));
    }
    public static IRuleBuilderOptions<T, ProjectStageBelongsToProjectDTO> BelongsToProject<T>(this IRuleBuilder<T, ProjectStageBelongsToProjectDTO> ruleBuilder, ProjectManagementSystemDbContext context)
    {
        return ruleBuilder.Must(x => context.StudentProjectStages.Where(s => s.Stage.Project.Id == x.ProjectId)
        .Any(s => s.Id == x.ProjectStageId));
    }
}