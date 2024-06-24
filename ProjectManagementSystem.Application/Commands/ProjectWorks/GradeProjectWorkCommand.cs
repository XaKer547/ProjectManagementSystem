using MediatR;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.Students;

namespace ProjectManagementSystem.Application.Commands.ProjectWorks;

public sealed record GradeProjectWorkCommand : IRequest
{
    public ProjectId ProjectId { get; init; }
    public StudentId StudentId { get; init; }
    public int Grade { get; init; }
}