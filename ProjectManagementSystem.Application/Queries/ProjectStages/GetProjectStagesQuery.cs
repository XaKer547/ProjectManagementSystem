using MediatR;
using ProjectManagementSystem.Domain.Projects;
using SharedKernel.DTOs.ProjectStages;

namespace ProjectManagementSystem.Application.Queries.ProjectStages;

public sealed record GetProjectStagesQuery : IRequest<IReadOnlyCollection<ProjectStagePreviewDTO>>
{
    public ProjectId ProjectId { get; init; }
}
