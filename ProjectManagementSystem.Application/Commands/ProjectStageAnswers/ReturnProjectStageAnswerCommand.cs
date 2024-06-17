using MediatR;
using ProjectManagementSystem.Application.Models;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.StudentProjectStages;

namespace ProjectManagementSystem.Application.Commands.ProjectStageAnswers;

public sealed record ReturnProjectStageAnswerCommand : IRequest
{
    public ProjectId ProjectId { get; init; }
    public StudentProjectStageId ProjectStageId { get; init; }
    public string? Remark { get; init; }
    public FileDTO? PinnedFile { get; init; }
}