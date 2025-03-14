﻿using FluentValidation;
using ProjectManagementSystem.API.Helpers;
using ProjectManagementSystem.Application.Commands.Projects;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.API.Validators.Projects;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator(ProjectManagementSystemDbContext context)
    {
        RuleFor(x => x.ProjectType)
            .IsInEnum();

        RuleFor(x => x.GroupId)
            .Exists(context);

        RuleFor(x => x.DisciplineId)
            .Exists(context);

        RuleFor(x => x.Deadline)
            .NotNull()
            .NotEarlierThanNow();
    }
}