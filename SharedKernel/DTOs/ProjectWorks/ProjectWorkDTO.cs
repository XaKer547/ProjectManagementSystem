namespace SharedKernel.DTOs.ProjectWorks;

public sealed record ProjectWorkDTO
{
    public string WorkName { get; init; }
    public int Progress { get; init; }
    public string LastStageStatus { get; init; }
}