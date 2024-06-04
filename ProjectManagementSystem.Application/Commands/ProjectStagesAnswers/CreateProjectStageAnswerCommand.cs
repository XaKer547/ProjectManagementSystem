﻿using MediatR;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectStageAnswers;
using ProjectManagementSystem.Domain.ProjectStages;

namespace ProjectManagementSystem.Application.Commands.ProjectStagesAnswers;

public sealed record CreateProjectStageAnswerCommand : IRequest<ProjectStageAnswerId>
{
    public ProjectId ProjectId { get; init; }
    public ProjectStageId ProjectStageId { get; init; }
    public string PinnedFile { get; init; }
}