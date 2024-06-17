namespace SharedKernel.DTOs.ProjectStageAnswers;

public class ProjectStageAnswerDTO
{
    public Guid Id { get; init; }
    public string StudentWork { get; init; }
    public string? AdditionalResponseFiles { get; init; }
    public string? Remark { get; init; }
    public bool Returned { get; init; }
}
