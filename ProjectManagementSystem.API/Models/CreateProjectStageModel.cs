using SharedKernel.DTOs.ProjectStages;

namespace ProjectManagementSystem.Infrastucture.Models;

public class CreateProjectStageModel
{
    public CreateProjectStageDTO CreateProjectStage { get; }
    public IEnumerable<IFormFile>? Files { get; }
}