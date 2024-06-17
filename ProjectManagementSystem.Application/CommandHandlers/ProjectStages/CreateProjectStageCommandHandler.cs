using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.ProjectStages;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.Services;
using ProjectManagementSystem.Domain.StudentProjectStages;

namespace ProjectManagementSystem.Application.CommandHandlers.ProjectStages;

public sealed class CreateProjectStageCommandHandler(IUnitOfWork unitOfWork, IFileManager fileManager, IValidator<CreateProjectStageCommand> validator) : IRequestHandler<CreateProjectStageCommand, ProjectStageId>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IFileManager fileManager = fileManager;
    private readonly IValidator<CreateProjectStageCommand> validator = validator;

    public async Task<ProjectStageId> Handle(CreateProjectStageCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var projectGroup = unitOfWork.Repository.Projects.Select(p => new
        {
            Project = p,
            p.Group,
        }).Single(p => p.Project.Id == request.ProjectId);

        var project = projectGroup.Project;

        var stage = ProjectStage.Create(request.Name, request.Description, request.Deadline, null);

        if (request.PinnedFiles is not null)
        {
            var pinnedFiles = await fileManager.SaveFiles(stage.Id, request.PinnedFiles);

            stage.UpdatePinnedFiles(pinnedFiles);
        }

        project.Stages.Add(stage);

        var group = projectGroup.Group;

        var students = unitOfWork.Repository.Students.Where(s => s.Group == group)
            .AsEnumerable();

        foreach (var student in students)
        {
            var studentStage = StudentProjectStage.Create(stage, student);

            unitOfWork.Repository.AddEntity(studentStage);
        }

        unitOfWork.Repository.UpdateEntity(project);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return stage.Id;
    }
}