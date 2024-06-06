using ProjectManagementSystem.Application.Models;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectStages;

namespace ProjectManagementSystem.Application.Commands.ProjectStageAnswers;

public sealed record ReturnProjectStageAnswerCommand
{
    public ProjectId ProjectId { get; init; }
    public ProjectStageId ProjectStageId { get; init; }
    public string? Remark { get; init; }
    public FileDTO? PinnedFile { get; init; }
}
