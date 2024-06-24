using MediatR;
using ProjectManagementSystem.Domain.StudentProjects;
using SharedKernel.DTOs.Projects;

namespace ProjectManagementSystem.Application.Queries.Projects;

public sealed record GetProjectQuery : IRequest<ProjectDTO>
{
    public StudentProjectId ProjectId { get; init; }
}
