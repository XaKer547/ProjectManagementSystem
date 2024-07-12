namespace SharedKernel.DTOs.ProjectWorks;

public sealed record ProjectWorkPreviewDTO
{
    public Guid StudentId { get; init; }
    public string StudentFullname { get; init; }
    public string WorkName { get; init; }
    public int Progress { get; init; }
    public string LastStageStatus { get; init; }
}