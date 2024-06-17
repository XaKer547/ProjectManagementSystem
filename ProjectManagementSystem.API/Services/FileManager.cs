﻿using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Application.Models;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Infrastucture.Data;
using ProjectManagementSystem.Infrastucture.Validators.Models;
using System.Linq;

namespace ProjectManagementSystem.Infrastucture.Services;

public class FileManager(ProjectManagementSystemDbContext context, IWebHostEnvironment webHost) : IFileManager
{
    private readonly ProjectManagementSystemDbContext context = context;
    private readonly IWebHostEnvironment webHost = webHost;

    public async Task<PinnedFile> SaveFile(ProjectStageId projectStageId, FileDTO file)
    {
        var stage = GetProjectStageOrThrow(projectStageId);

        return await SaveFile(stage, file);
    }

    public async Task<PinnedFile[]> SaveFiles(ProjectStageId projectStageId, IEnumerable<FileDTO> files)
    {
        var stage = GetProjectStageOrThrow(projectStageId);

        var pinnedFiles = new List<PinnedFile>();

        foreach (var file in files)
        {
            var pinnedFile = await SaveFile(stage, file);

            pinnedFiles.Add(pinnedFile);
        }

        return [.. pinnedFiles];
    }

    private ProjectStage GetProjectStageOrThrow(ProjectStageId projectStageId)
    {
        var stage = context.ProjectStages.Include(p => p.Project)
         .SingleOrDefault(p => p.Id == projectStageId);

        if (stage is null)
        {
            var error = new ValidationError("", "Данный проект или его этап не существует", "404");

            throw new Validators.Exceptions.ValidationException([error]);
        }

        return stage;
    }
    private async Task<PinnedFile> SaveFile(ProjectStage stage, FileDTO file)
    {
        var pinnedFile = PinnedFile.Create(stage.Project.Name, stage.Name, file.Name);

        var path = Path.Combine(webHost.WebRootPath, pinnedFile.FilePath);

        await File.WriteAllBytesAsync(path, file.File);

        return pinnedFile;
    }
}