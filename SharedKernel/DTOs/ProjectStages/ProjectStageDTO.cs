using SharedKernel.DTOs.ProjectStageAnswers;

namespace SharedKernel.DTOs.ProjectStages;

public sealed record ProjectStageDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public DateTime Deadline { get; init; }
    public ProjectStageAnswerDTO[] Answers { get; init; }
}
