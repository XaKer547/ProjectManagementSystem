using ProjectManagementSystem.Application.Models;
using ProjectManagementSystem.Domain.ProjectStages;

namespace ProjectManagementSystem.Application.Services;

public interface IFileManager
{
    Task<Guid> SaveFile(ProjectStageId projectStageId, FileDTO file);
    Task<Guid[]> SaveFiles(ProjectStageId projectStageId, IEnumerable<FileDTO> files);
}
