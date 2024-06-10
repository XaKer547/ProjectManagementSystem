using FluentValidation;
using MediatR;
using ProjectManagementSystem.Application.Commands.ProjectStageAnswers;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.ProjectStageAnswers;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.Services;

namespace ProjectManagementSystem.Application.CommandHandlers.ProjectStageAnswers;

public sealed class UpdateProjectStageAnswerCommandHandler(IUnitOfWork unitOfWork, IFileManager fileManager, IValidator<UpdateProjectStageAnswerCommand> validator) : IRequestHandler<UpdateProjectStageAnswerCommand>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IFileManager fileManager = fileManager;
    private readonly IValidator<UpdateProjectStageAnswerCommand> validator = validator;

    public async Task Handle(UpdateProjectStageAnswerCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var projectStage = unitOfWork.Repository.StudentProjectStages.Where(s => s.Id == request.ProjectStageId)
            .Select(s => new
            {
                s.Stage.Id,
                Stage = s,
            })
            .Single();

        var stage = projectStage.Stage;

        var pinnedFileId = await fileManager.SaveFile(projectStage.Id, request.PinnedFile);

        var pinnedFile = unitOfWork.Repository.PinnedFiles.Single(p => p.Id == pinnedFileId);

        var answer = ProjectStageAnswer.Create(pinnedFile);

        stage.AddAnswer(answer);

        unitOfWork.Repository.UpdateEntity(stage);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}