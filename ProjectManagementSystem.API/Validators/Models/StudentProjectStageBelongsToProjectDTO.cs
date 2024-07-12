using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.StudentProjectStages;

namespace ProjectManagementSystem.API.Validators.Models;

public record StudentProjectStageBelongsToProjectDTO
{
    public ProjectId ProjectId { get; init; }
    public StudentProjectStageId ProjectStageId { get; init; }
}
