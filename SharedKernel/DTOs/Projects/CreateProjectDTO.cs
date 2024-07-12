using SharedKernel.DTOs.ProjectType;

namespace SharedKernel.DTOs.Projects;

public sealed record CreateProjectDTO
{
    public ProjectTypes ProjectType { get; init; }
    public Guid DisciplineId { get; init; }
    public Guid GroupId { get; init; }
    public DateTime Deadline { get; init; }
}