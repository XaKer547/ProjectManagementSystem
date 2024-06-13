using MediatR;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.StudentProjectStages;
using SharedKernel.DTOs.ProjectStages;

namespace ProjectManagementSystem.Application.Queries.ProjectStages;

public sealed record GetProjectStageQuery : IRequest<ProjectStageDTO>
{
    public ProjectId ProjectId { get; init; }
    public StudentProjectStageId ProjectStageId { get; init; }
}
