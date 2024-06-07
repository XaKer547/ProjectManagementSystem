﻿using FluentValidation;
using ProjectManagementSystem.API.Validators.Disciplines;
using ProjectManagementSystem.API.Validators.Grops;
using ProjectManagementSystem.API.Validators.Models;
using ProjectManagementSystem.API.Validators.Projects;
using ProjectManagementSystem.API.Validators.ProjectStages;
using ProjectManagementSystem.API.Validators.Students;
using ProjectManagementSystem.Domain.Disciplines;
using ProjectManagementSystem.Domain.Groups;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.Students;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.API.Helpers;

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
        return ruleBuilder.Must(x => context.ProjectStages.Where(s => s.Project.Id == x.ProjectId)
        .Any(s => s.Id == x.ProjectStageId));
    }
}