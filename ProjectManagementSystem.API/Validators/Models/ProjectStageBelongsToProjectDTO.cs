using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.StudentProjectStages;

namespace ProjectManagementSystem.Infrastucture.Validators.Models;

public record ProjectStageBelongsToProjectDTO
{
    public ProjectId ProjectId { get; init; }
    public StudentProjectStageId ProjectStageId { get; init; }
}
