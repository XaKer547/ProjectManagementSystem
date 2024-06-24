namespace SharedKernel.DTOs.ProjectWorks;

public sealed record CreateProjectWorkDTO
{
    public Guid StudentId { get; init; }
    public string SubjectArea { get; init; }
    public string Name { get; init; }
}