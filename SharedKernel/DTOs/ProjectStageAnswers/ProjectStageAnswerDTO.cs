namespace SharedKernel.DTOs.ProjectStageAnswers;

public sealed record ProjectStageAnswerDTO
{
    public Guid Id { get; init; }
    public string StudentWork { get; init; }
    public string? AdditionalResponseFiles { get; init; }
    public string? Remark { get; init; }
    public bool Returned { get; init; }
}
