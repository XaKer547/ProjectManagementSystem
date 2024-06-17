using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Infrastucture.Validators.Models;
using ProjectManagementSystem.Application.Models;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.Infrastucture.Services;

public class FileManager(ProjectManagementSystemDbContext context, IWebHostEnvironment webHost) : IFileManager
{
    private readonly ProjectManagementSystemDbContext context = context;
    private readonly IWebHostEnvironment webHost = webHost;

    public async Task<PinnedFile> SaveFile(ProjectStageId projectStageId, FileDTO file)
    {
        var stage = context.ProjectStages.Include(p => p.Project)
          .SingleOrDefault(p => p.Id == projectStageId);

        if (stage is null)
        {
            var error = new ValidationError("", "Данный проект или его этап не существует", "404");

            throw new Validators.Exceptions.ValidationException([error]);
        }

        var pinnedFile = PinnedFile.Create(stage.Project.Name, stage.Name, file.Name);

        var path = Path.Combine(webHost.WebRootPath, pinnedFile.FilePath);

        File.WriteAllBytes(path, file.File);

        return pinnedFile;
    }

    public async Task<PinnedFile[]> SaveFiles(ProjectStageId projectStageId, IEnumerable<FileDTO> files)
    {
        var stage = context.ProjectStages.Include(p => p.Project)
           .SingleOrDefault(p => p.Id == projectStageId);

        if (stage is null)
        {
            var error = new ValidationError("", "Данный проект или его этап не существует", "404");

            throw new Validators.Exceptions.ValidationException([error]);
        }

        var pinnedFiles = files.Select(f =>
        {
            var pinnedFile = PinnedFile.Create(stage.Project.Name, stage.Name, f.Name);

            var path = Path.Combine(webHost.WebRootPath, pinnedFile.FilePath);

            File.WriteAllBytes(path, f.File);

            return pinnedFile;
        }).ToArray();

        return pinnedFiles;
    }
}