using MediatR;
using ProjectManagementSystem.Application.Models;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectStages;

namespace ProjectManagementSystem.Application.Commands.ProjectStages;

public sealed record CreateProjectStageCommand : IRequest<ProjectStageId>
{
    public ProjectId ProjectId { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public DateTime Deadline { get; init; }
    public FileDTO[]? PinnedFiles { get; init; }
}