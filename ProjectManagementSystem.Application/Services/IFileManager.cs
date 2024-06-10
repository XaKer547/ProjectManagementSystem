using ProjectManagementSystem.Application.Models;
using ProjectManagementSystem.Domain.ProjectStages;

namespace ProjectManagementSystem.Application.Services;

public interface IFileManager
{
    Task<PinnedFile> SaveFile(ProjectStageId projectStageId, FileDTO file);
    Task<PinnedFile[]> SaveFiles(ProjectStageId projectStageId, IEnumerable<FileDTO> files);
}
