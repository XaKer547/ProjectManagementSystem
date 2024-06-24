﻿using MediatR;
using ProjectManagementSystem.Domain.Disciplines;
using ProjectManagementSystem.Domain.Groups;
using ProjectManagementSystem.Domain.Projects;
using SharedKernel.DTOs.ProjectType;

namespace ProjectManagementSystem.Application.Commands.Projects;

public sealed record CreateProjectCommand : IRequest<ProjectId>
{
    public ProjectTypes ProjectType { get; init; }
    public DisciplineId DisciplineId { get; init; }
    public GroupId GroupId { get; init; }
    public DateTime Deadline { get; init; }
}
