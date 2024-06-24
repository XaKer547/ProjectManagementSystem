using SharedKernel.DTOs.ProjectType;

namespace SharedKernel.DTOs.Projects;

public sealed record UpdateProjectDTO
{
    public Guid GroupId { get; init; }
    public Guid DisciplineId { get; init; }
    public ProjectTypes ProjectType { get; init; }
}
