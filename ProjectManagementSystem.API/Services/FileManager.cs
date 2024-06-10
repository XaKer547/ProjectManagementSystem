using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.API.Validators.Models;
using ProjectManagementSystem.Application.Models;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Infrastucture.Data;

namespace ProjectManagementSystem.API.Services;

public class FileManager(ProjectManagementSystemDbContext context, IWebHostEnvironment webHost) : IFileManager
{
    private readonly ProjectManagementSystemDbContext context = context;
    private readonly IWebHostEnvironment webHost = webHost;

    public async Task<Guid> SaveFile(ProjectStageId projectStageId, FileDTO file)
    {
        var stage = context.ProjectStages.Include(p => p.Project)
          .SingleOrDefault(p => p.Id == projectStageId);

        if (stage is null)
        {
            var error = new ValidationError("", "Данный проект или его этап не существует", "404");

            throw new Validators.Exceptions.ValidationException([error]);
        }

        var pinnedFile = PinnedFile.Create(stage.Project.Name, stage.Name, file.Name);

        var path = Path.Combine(webHost.WebRootPath, pinnedFile.GetPath());

        File.WriteAllBytes(path, file.File);

        return pinnedFile.Id;
    }

    public async Task<Guid[]> SaveFiles(ProjectStageId projectStageId, IEnumerable<FileDTO> files)
    {
        var stage = context.ProjectStages.Include(p => p.Project)
           .SingleOrDefault(p => p.Id == projectStageId);

        if (stage is null)
        {
            var error = new ValidationError("", "Данный проект или его этап не существует", "404");

            throw new Validators.Exceptions.ValidationException([error]);
        }

        var filesGuids = new List<Guid>();

        foreach (var file in files)
        {
            var pinnedFile = PinnedFile.Create(stage.Project.Name, stage.Name, file.Name);

            var path = Path.Combine(webHost.WebRootPath, pinnedFile.GetPath());

            File.WriteAllBytes(path, file.File);

            filesGuids.Add(pinnedFile.Id);
        }

        return [.. filesGuids];
    }
}