using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectStages;

namespace ProjectManagementSystem.API.Validators.Models;

public record ProjectStageBelongsToProjectDTO
{
    public ProjectId ProjectId { get; init; }
    public ProjectStageId ProjectStageId { get; init; }
}
