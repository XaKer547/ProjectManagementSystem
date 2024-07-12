using MediatR;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.Students;

namespace ProjectManagementSystem.Application.Commands.ProjectWorks;

public record DeleteProjectWorkCommand : IRequest
{
    public ProjectId ProjectId { get; init; }
    public StudentId StudentId { get; init; }
}
