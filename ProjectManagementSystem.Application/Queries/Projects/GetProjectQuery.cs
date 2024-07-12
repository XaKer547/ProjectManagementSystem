using MediatR;
using ProjectManagementSystem.Domain.ProjectWorks;
using SharedKernel.DTOs.Projects;

namespace ProjectManagementSystem.Application.Queries.Projects;

public sealed record GetProjectQuery : IRequest<ProjectDTO>
{
    public ProjectWorkId ProjectWorkId { get; init; }
}
