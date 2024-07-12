using SharedKernel.DTOs.ProjectStages;

namespace ProjectManagementSystem.API.Models;

public class CreateProjectStageModel
{
    public CreateProjectStageDTO CreateProjectStage { get; }
    public IEnumerable<IFormFile>? Files { get; }
}