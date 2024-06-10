﻿using MediatR;
using ProjectManagementSystem.Application.Models;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.StudentProjectStages;

namespace ProjectManagementSystem.Application.Commands.ProjectStageAnswers;

public sealed record UpdateProjectStageAnswerCommand : IRequest
{
    public ProjectId ProjectId { get; init; }
    public StudentProjectStageId ProjectStageId { get; init; }
    public FileDTO PinnedFile { get; init; }
}