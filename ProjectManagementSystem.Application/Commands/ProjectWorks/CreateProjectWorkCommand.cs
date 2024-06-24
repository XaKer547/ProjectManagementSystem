using MediatR;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectWorks;
using ProjectManagementSystem.Domain.Students;

namespace ProjectManagementSystem.Application.Commands.ProjectWorks;

public sealed record CreateProjectWorkCommand : IRequest<ProjectWorkId>
{
    public ProjectId ProjectId { get; init; }
    public StudentId StudentId { get; init; }
    public string SubjectArea { get; init; }
    public string Name { get; init; }
}
