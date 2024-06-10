using SharedKernel.DTOs.ProjectStages;

namespace ProjectManagementSystem.Infrastucture.Models;

public class UpdateProjectStageModel
{
    public UpdateProjectStageDTO UpdateProjectStage { get; }
    public IEnumerable<IFormFile>? Files { get; }
}
