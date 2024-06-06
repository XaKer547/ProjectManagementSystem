using SharedKernel.DTOs.ProjectType;

namespace SharedKernel.DTOs.Projects;

public sealed record CreateProjectDTO
{
    public string Name { get; init; }
    public string SubjectArea { get; init; }
    public ProjectTypes ProjectType { get; init; }
    public Guid DisciplineId { get; init; }
    public Guid GroupId { get; init; }
}